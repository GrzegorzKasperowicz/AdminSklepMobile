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
	public partial class OrderPage : ContentPage
	{
		OrderViewModel _viewModel;
		public OrderPage ()
		{
			InitializeComponent ();
			BindingContext = _viewModel = new OrderViewModel ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			_viewModel.OnAppearing();
        }
    }
}