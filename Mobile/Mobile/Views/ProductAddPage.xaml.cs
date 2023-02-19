using AdminServiceConnection;
using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductAddPage : ContentPage
    {
        public ProductForView Item { get; set; }
        public ProductAddPage()
        {
            InitializeComponent();
            BindingContext = new ProductAddViewModel();
        }
    }
}