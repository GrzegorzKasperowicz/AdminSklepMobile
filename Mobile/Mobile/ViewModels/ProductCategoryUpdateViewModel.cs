using Mobile.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ProductCategoryUpdateViewModel : BaseViewModel<ProductCategoryForView>
    {
        private int id;
        private int itemId;
        private string title;
        private string description;


        public ProductCategoryUpdateViewModel()
        {
            UpdateCommand = new Command(OnUpdate, ValidateUpdate);
            this.PropertyChanged += (_, __) => UpdateCommand.ChangeCanExecute();
            CancelCommand = new Command(OnCancel);
        }
        private bool ValidateUpdate()
        {
            return !String.IsNullOrEmpty(description)
                && !String.IsNullOrEmpty(title);
        }
        public Command UpdateCommand { get; }
        public Command CancelCommand { get; }


        public string Title1
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                ItemId = item.IdProductCategory;
                Title1 = item.Title;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnUpdate()
        {
            ProductCategoryForView newItem = new ProductCategoryForView()
            {
                IdProductCategory = Id,
                Title = Title1,
                Description = Description
            };
            await DataStore.UpdateItemAsync(newItem);

            await Shell.Current.GoToAsync("..");

        }
    }
}
