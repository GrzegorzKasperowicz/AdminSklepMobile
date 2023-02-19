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
    class OrderDataStore : AbstractDataStore, IDataStore<OrderForView>
    {
        public List<OrderForView> Items { get; set; }
        public OrderDataStore()
        {
            var itemsFromService = adminServiceConnectionReference.OrderAllAsync().Result;
            Items = itemsFromService.ToList();
        }

        public async Task<bool> AddItemAsync(OrderForView item)
        {
            var itemToAdd = new Order
            {
            OrderDate= DateTime.Now,
            Quantity= item.Quantity,
            Total= item.Total,
            };
            itemToAdd.CopyPropertiesExtension(item);
            var itemsFromService = adminServiceConnectionReference.OrderAsync(itemToAdd).Result;
            Items.Add(itemsFromService);
            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((OrderForView arg) => arg.IdOrder == id).FirstOrDefault();
            await adminServiceConnectionReference.Order4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<OrderForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(p => p.IdOrder == id));
        }

        public async Task<IEnumerable<OrderForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public Task<bool> UpdateItemAsync(OrderForView item)
        {
            var oldItems = Items.Where((OrderForView arg) => arg.IdOrder == item.IdOrder).FirstOrDefault();
            Items.Remove(oldItems);
            Items.Add(item);
            return Task.FromResult(true);
        }
    }
}
