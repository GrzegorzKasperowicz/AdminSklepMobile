
using AdminServiceConnection;
using Mobile.Models;
using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ProductProducerDataStore : AbstractDataStore, IDataStore<ProductProducerForView>
    {
        public List<ProductProducerForView> Items { get; }
        public ProductProducerDataStore()
        {
            var itemsFromService = adminServiceConnectionReference.ProductProducerAllAsync().Result;
            Items = new List<ProductProducerForView>();
            Items = itemsFromService.Select(producer => new ProductProducerForView(producer)).ToList();
        }

        public async Task<bool> AddItemAsync(ProductProducerForView item)
        {
            var itemToAdd = new ProductProducer
            {
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Destiny= item.Destiny,  
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActicve = true
            };
            var itemsFromService = new ProductProducerForView(adminServiceConnectionReference.ProductProducerAsync(itemToAdd).Result);
            Items.Add(itemsFromService);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ProductProducerForView item)
        {
            var oldItem = Items.Where((ProductProducerForView arg) => arg.IdProductProducer == item.IdProductProducer).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductProducerForView arg) => arg.IdProductProducer == id).FirstOrDefault();
            await adminServiceConnectionReference.ProductProducer4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<ProductProducerForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s=>s.IdProductProducer == id));
        }

        public async Task<IEnumerable<ProductProducerForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}
