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
    public class ProductTypeViewModel:BaseViewModel<ProductTypeForView>
    {
        private ProductTypeForView _selectedItem;

        public ObservableCollection<ProductTypeForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ProductTypeForView> DeleteCommand { get; }
        public Command<ProductTypeForView> ItemTapped { get; }

        public ProductTypeViewModel()
        {
            Title = "BrowseProductProducers";
            Items = new ObservableCollection<ProductTypeForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ProductTypeForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<ProductTypeForView>(Delete);
        }

        private async void Delete(ProductTypeForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdProductType);
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

        public ProductTypeForView SelectedItem
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
            await Shell.Current.GoToAsync(nameof(ProductTypeAddPage));
        }

        async void OnItemSelected(ProductTypeForView item)
        {
            if (item == null) return;
            //await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.Id)}={item.IdProductCategory}");
        }
    }
}