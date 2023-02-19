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
    public partial class OrderAddPage : ContentPage
    {
        public OrderForView Item { get; set; }
        public OrderAddPage()
        {
            InitializeComponent();
            BindingContext = new OrderAddViewModel();
        }
    }
}