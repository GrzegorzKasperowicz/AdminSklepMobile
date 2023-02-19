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
    public class ProductProducerAddViewModel:BaseViewModel<ProductProducerForView>
    {

        private int id;
        private string title;
        private string description;

        public ProductProducerAddViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrEmpty(title)
                && !String.IsNullOrEmpty(description);
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ProductProducerForView newItem = new ProductProducerForView()
            {
                IdProductProducer = Id,
                Title = Title1,
                Description = Description
            };
            await DataStore.AddItemAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }

}
