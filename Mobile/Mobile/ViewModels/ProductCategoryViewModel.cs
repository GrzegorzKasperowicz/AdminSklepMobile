using AdminServiceConnection;
using Mobile.Models;
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
    public class ProductCategoryViewModel : BaseViewModel<ProductCategoryForView>
    {
        private ProductCategoryForView _selectedItem;

        public ObservableCollection<ProductCategoryForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ProductCategoryForView> DeleteCommand { get; }
        public Command<ProductCategoryForView> ItemTapped { get; }

        public ProductCategoryViewModel()
        {
            Title = "BrowseProductCategory";
            Items = new ObservableCollection<ProductCategoryForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ProductCategoryForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<ProductCategoryForView>(Delete);
        }

        private async void Delete(ProductCategoryForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdProductCategory);
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

        public ProductCategoryForView SelectedItem
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
            await Shell.Current.GoToAsync(nameof(ProductCategoryAddPage));
        }

        async void OnItemSelected(ProductCategoryForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.ItemId)}={item.IdProductCategory}");
        }
    }
}