using AdminServiceConnection;
using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ProductAddViewModel : BaseViewModel<ProductForView>
    {
        private int id;
        private string code;
        private string title;
        private double price;
        private string description;
        private ProductTypeForView selectedProductType;
        private ProductCategoryForView selectedProductCategory;
        private ProductProducerForView selectedProductProducer;

        public List<ProductTypeForView> ProductType
        {
            get
            {
                return new ProductTypeDataStore().Items;
            }
        }
        public List<ProductCategoryForView> ProductCategory
        {
            get
            {
                return new ProductCategoryDataStore().Items;
            }
        }
        public List<ProductProducerForView> ProductProducer
        {
            get
            {
                return new ProductProducerDataStore().Items;
            }
        }

        public ProductAddViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            selectedProductCategory = new ProductCategoryForView();
            selectedProductType = new ProductTypeForView();
            selectedProductProducer = new ProductProducerForView();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrEmpty(Title)
                && !String.IsNullOrEmpty(selectedProductCategory.Title);
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
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
        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public ProductTypeForView SelectedProductType
        {
            get => selectedProductType;
            set => SetProperty(ref selectedProductType, value);
        }
        public ProductCategoryForView SelectedProductCategory
        {
            get => selectedProductCategory;
            set => SetProperty(ref selectedProductCategory, value);
        }
        public ProductProducerForView SelectedProductProducer
        {
            get => selectedProductProducer;
            set => SetProperty(ref selectedProductProducer, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");

        }

        private async void OnSave()
        {
            ProductForView newItem = new ProductForView()
            {
                IdProduct = Id,
                Code= Code,
                Title= Title,   
                Price= Price,
                Description= Description,
                IdProductType = selectedProductType.IdProductType,
                IdProductCategory= selectedProductCategory.IdProductCategory,
                IdProductProducer= selectedProductProducer.IdProductProducer,
                ProductCategoryTitle = selectedProductCategory.Title,
                ProductProducerTitle = SelectedProductProducer.Title,
                ProductTypeTitle = selectedProductType.Title,
                
            };
            await DataStore.AddItemAsync(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }
}
