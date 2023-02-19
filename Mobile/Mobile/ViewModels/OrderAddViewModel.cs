using AdminServiceConnection;
using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class OrderAddViewModel:BaseViewModel<OrderForView>
    {
        private int id;
        private ProductForView selectedProduct;
        private double quantity;
        private double total;
        private ClientForView selectedClient;

        public List<ClientForView> Client
        {
            get
            {
                return new ClientDataStore().Items;
            }
        }
        public List<ProductForView> Product
        {
            get
            {
                return new ProductDataStore().Items;
            }
        }

        public OrderAddViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            selectedClient= new ClientForView();
            selectedProduct= new ProductForView();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrEmpty(selectedClient.LastName)
                && !String.IsNullOrEmpty(selectedProduct.Title);
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public ProductForView SelectedProduct
        {
            get => selectedProduct;
            set => SetProperty(ref selectedProduct, value);
        }
        public double Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }
        public double Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }
        public ClientForView SelectedClient
        {
            get => selectedClient;
            set => SetProperty(ref selectedClient, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            OrderForView newItem = new OrderForView()
            {
                IdOrder = Id,
                IdProduct = selectedProduct.IdProduct,
                Quantity = Quantity,
                Total = Total,
                IdClient = selectedClient.IdClient

            };
            await DataStore.AddItemAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }
}
