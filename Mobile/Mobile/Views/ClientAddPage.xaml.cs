using Mobile.Models;
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
    public partial class ClientAddPage : ContentPage
    {
        public ClientForView Item { get; set; }
        public ClientAddPage()
        {
            InitializeComponent();
            BindingContext = new ClientAddViewModel();
        }
    }
}