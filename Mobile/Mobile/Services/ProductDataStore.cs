using AdminServiceConnection;
using Mobile.Extensions;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ProductDataStore : AbstractDataStore, IDataStore<ProductForView>
    {
        public List<ProductForView> Items { get; set; }
        public ProductDataStore()
        {
             Refresh();
        }

        public async Task<bool> AddItemAsync(ProductForView item)
        {
            var itemToAdd = new Product
            {
                Code = item.Code,
                Title = item.Title,
                Price = item.Price,
                Description = item.Description,
                Created = DateTimeOffset.Now,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };
            itemToAdd.CopyPropertiesExtension(item);
            var itemsFromService = adminServiceConnectionReference.ProductAsync(itemToAdd).Result;
            Items.Add(itemsFromService);
            Refresh();
            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductForView arg) => arg.IdProduct == id).FirstOrDefault();
            await adminServiceConnectionReference.Product4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<ProductForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(p => p.IdProduct == id));
        }

        public async Task<IEnumerable<ProductForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public Task<bool> UpdateItemAsync(ProductForView item)
        {
            var oldItems = Items.Where((ProductForView arg) => arg.IdProduct == item.IdProduct).FirstOrDefault();
            Items.Remove(oldItems);
            Items.Add(item);
            return Task.FromResult(true);
        }

        public async Task Refresh()
        {

            var itemsFromService = adminServiceConnectionReference.ProductAllAsync().Result;
            Items = itemsFromService.ToList();

        }
    }
}
