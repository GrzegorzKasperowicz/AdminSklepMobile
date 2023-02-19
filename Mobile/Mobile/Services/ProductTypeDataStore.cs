using AdminServiceConnection;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ProductTypeDataStore : AbstractDataStore, IDataStore<ProductTypeForView>
    {
        public List<ProductTypeForView> Items { get; set; }
        public ProductTypeDataStore()
        {
            var itemsFromService = adminServiceConnectionReference.ProductTypeAllAsync().Result;
            Items = new List<ProductTypeForView>();
            Items = itemsFromService.Select(type => new ProductTypeForView(type)).ToList();
        }

        public async Task<bool> AddItemAsync(ProductTypeForView item)
        {
            var itemToAdd = new ProductType
            {
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };
            var itemsFromService = new ProductTypeForView(adminServiceConnectionReference.ProductTypeAsync(itemToAdd).Result);
            Items.Add(itemsFromService);
            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductTypeForView arg)=>arg.IdProductType== id).FirstOrDefault();
            await adminServiceConnectionReference.ProductType4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<ProductTypeForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s=>s.IdProductType== id));    
        }

        public async Task<IEnumerable<ProductTypeForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ProductTypeForView item)
        {
            var oldItem = Items.Where((ProductTypeForView arg)=>arg.IdProductType == item.IdProductType).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
