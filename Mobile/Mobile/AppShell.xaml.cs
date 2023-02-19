using Mobile.ViewModels;
using Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ProductCategoryAddPage), typeof(ProductCategoryAddPage));
            Routing.RegisterRoute(nameof(ProductCategoryUpdatePage), typeof(ProductCategoryUpdatePage));
            Routing.RegisterRoute(nameof(ProductTypeAddPage), typeof(ProductTypeAddPage));
            Routing.RegisterRoute(nameof(ProductProducerAddPage), typeof(ProductProducerAddPage));
            Routing.RegisterRoute(nameof(ClientAddPage), typeof(ClientAddPage));
            Routing.RegisterRoute(nameof(ProductAddPage), typeof(ProductAddPage));
            Routing.RegisterRoute(nameof(OrderAddPage), typeof(OrderAddPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
