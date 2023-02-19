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
    public class ProductViewModel : BaseViewModel<ProductForView>
    {
        private ProductForView _selectedItem;

        public ObservableCollection<ProductForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ProductForView> DeleteCommand { get; }
        public Command<ProductForView> ItemTapped { get; }

        public ProductViewModel()
        {
            Title = "BrowseProductCategory";
            Items = new ObservableCollection<ProductForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ProductForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<ProductForView>(Delete);
        }

        private async void Delete(ProductForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdProduct);
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

        public ProductForView SelectedItem
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
            await Shell.Current.GoToAsync(nameof(ProductAddPage));
        }

        async void OnItemSelected(ProductForView item)
        {
            if (item == null) return;
            //await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.Id)}={item.IdProductCategory}");
        }
    }
}