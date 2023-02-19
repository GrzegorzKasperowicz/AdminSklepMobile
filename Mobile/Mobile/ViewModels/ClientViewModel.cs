using Mobile.Models;
using Mobile.Services;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ClientViewModel: BaseViewModel<ClientForView>
    {
        private ClientForView _selectedItem;

        public ObservableCollection<ClientForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ClientForView> DeleteCommand { get; }
        public Command<ClientForView> ItemTapped { get; }

        public ClientViewModel()
        {
            Title = "BrowseProductCategory";
            Items = new ObservableCollection<ClientForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ClientForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<ClientForView>(Delete);
        }

        private async void Delete(ClientForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdClient);
            await ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public ClientForView SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public void Delete() { }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ClientAddPage));
        }

        async void OnItemSelected(ClientForView item)
        {
            if (item == null) return;
            //await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.Id)}={item.IdProductCategory}");
        }
    }
}