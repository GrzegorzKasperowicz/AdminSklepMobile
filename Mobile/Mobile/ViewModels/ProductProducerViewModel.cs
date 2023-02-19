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
    public class ProductProducerViewModel : BaseViewModel<ProductProducerForView>
    {
        private ProductProducerForView _selectedItem;

        public ObservableCollection<ProductProducerForView> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<ProductProducerForView> DeleteCommand { get; }
        public Command<ProductProducerForView> ItemTapped { get; }

        public ProductProducerViewModel()
        {
            Title = "BrowseProductProducers";
            Items = new ObservableCollection<ProductProducerForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<ProductProducerForView>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<ProductProducerForView>(Delete);
        }

        private async void Delete(ProductProducerForView obj)
        {
            await DataStore.DeleteItemAsync(obj.IdProductProducer);
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
        public ProductProducerForView SelectedItem
        {
            get=> _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public void Delete() { }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ProductProducerAddPage));
        }

        async void OnItemSelected(ProductProducerForView item)
        {
            if (item == null) return;
            //await Shell.Current.GoToAsync($"{nameof(ProductCategoryUpdatePage)}?{nameof(ProductCategoryUpdateViewModel.Id)}={item.IdProductCategory}");
        }
    }
}