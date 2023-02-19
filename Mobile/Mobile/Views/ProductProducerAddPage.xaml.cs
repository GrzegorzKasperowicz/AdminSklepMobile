using Mobile.Models;
using Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductProducerAddPage : ContentPage
    {
        public ProductProducerForView Item { get; set; }   
        public ProductProducerAddPage()
        {
            InitializeComponent();
            BindingContext = new ProductProducerAddViewModel();
        }
    }
}