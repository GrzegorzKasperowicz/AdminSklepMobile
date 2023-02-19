using AdminServiceConnection;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ClientDataStore : AbstractDataStore, IDataStore<ClientForView>
    {
        public List<ClientForView> Items { get; set; }
        public ClientDataStore() 
        {
            var itemsFromService = adminServiceConnectionReference.ClientAllAsync().Result;
            Items = new List<ClientForView>();
            Items = itemsFromService.Select(client => new ClientForView(client)).ToList(); 
        }

        public async Task<bool> AddItemAsync(ClientForView item)
        {
            var itemToAdd = new Client
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Street = item.Street,
                HouseNumber = item.HouseNumber,
                ApartmentNumber = item.ApartmentNumber,
                City = item.City,
                Province = item.Province,
                PostalCode = item.PostalCode,
                Country = item.Country,
                PhoneNumer = item.PhoneNumber,
                Email = item.Email,
            };
            var itemsFromService = new ClientForView(adminServiceConnectionReference.ClientAsync(itemToAdd).Result);
            Items.Add(itemsFromService);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ClientForView arg)=>arg.IdClient== id).FirstOrDefault();
            await adminServiceConnectionReference.Client4Async(id);
            Items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<ClientForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(c=>c.IdClient== id));
        }

        public async Task<IEnumerable<ClientForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ClientForView item)
        {
            var oldItem = Items.Where((ClientForView arg)=>arg.IdClient == item.IdClient).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
            return await Task.FromResult(true);
        }
    }
}
