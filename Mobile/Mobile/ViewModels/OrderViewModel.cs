using AdminServiceConnection;
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
    class OrderViewModel:BaseViewModel<OrderForView>
    {

        private OrderForView _selectedItem;

        public ObservableCollection<OrderForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<OrderForView> DeleteCommand { get; }
        public Command<OrderForView> ItemTapped { get; }

        public OrderViewModel()
        {
            Title = "BrowseOrders";
            Items = new ObservableCollection<OrderForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<OrderForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<OrderForView>(Delete);
        }

        private async void Delete(OrderForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdOrder);
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

        public OrderForView SelectedItem
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
            await Shell.Current.GoToAsync(nameof(OrderAddPage));
        }

        async void OnItemSelected(OrderForView item)
        {
            if (item == null) return;
            //await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.Id)}={item.IdProductCategory}");
        }
    }
}