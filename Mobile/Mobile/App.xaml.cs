using Mobile.Services;
using Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ProductCategoryDataStore>();
            DependencyService.Register<ProductProducerDataStore>();
            DependencyService.Register<ProductTypeDataStore>();
            DependencyService.Register<ProductDataStore>();
            DependencyService.Register<ClientDataStore>();
            DependencyService.Register<OrderDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
