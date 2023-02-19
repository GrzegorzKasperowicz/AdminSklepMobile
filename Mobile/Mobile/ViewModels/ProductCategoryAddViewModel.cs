using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ProductCategoryAddViewModel : BaseViewModel<ProductCategoryForView>
    {
        private int id;
        private string title;
        private string description;

        public ProductCategoryAddViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrEmpty(description)
                && !String.IsNullOrEmpty(title);
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ProductCategoryForView newItem = new ProductCategoryForView()
            {
                IdProductCategory = Id,
                Title = Title,
                Description = Description
            };
            await DataStore.AddItemAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }

}
