using AdminServiceConnection;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ProductCategoryDataStore : AbstractDataStore, IDataStore<ProductCategoryForView>
    {
        public List<ProductCategoryForView> Items { get; set; }
        public ProductCategoryDataStore() 
        {
            var itemsFromService = adminServiceConnectionReference.ProductCategoryAllAsync().Result;
            Items = new List<ProductCategoryForView>();
            Items = itemsFromService.Select(category => new ProductCategoryForView(category)).ToList();
        }

        public async Task<bool> AddItemAsync(ProductCategoryForView item)
        {
            var itemToAdd = new ProductCategory
            {
                IdProductCategory = item.IdProductCategory,
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };

            var itemsFromService = new ProductCategoryForView(adminServiceConnectionReference.ProductCategoryAsync(itemToAdd).Result);
            Items.Add(itemsFromService);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductCategoryForView arg) => arg.IdProductCategory == id).FirstOrDefault();
            await adminServiceConnectionReference.ProductCategory4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<ProductCategoryForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s=>s.IdProductCategory == id));
        }

        public async Task<IEnumerable<ProductCategoryForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ProductCategoryForView item)
        {
            var oldItem = Items.Where((ProductCategoryForView arg)=>arg.IdProductCategory == item.IdProductCategory).FirstOrDefault();
            await adminServiceConnectionReference.ProductCategory4Async(item.IdProductCategory);
            Items.Remove(oldItem);

            var itemToAdd = new ProductCategory
            {
                IdProductCategory = item.IdProductCategory,
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };

            var itemsFromService = new ProductCategoryForView(adminServiceConnectionReference.ProductCategoryAsync(itemToAdd).Result);
            Items.Add(itemsFromService);
            return await Task.FromResult(true);
        }
    }
}
