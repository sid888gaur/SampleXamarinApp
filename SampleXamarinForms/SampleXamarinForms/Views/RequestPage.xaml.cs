using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SampleXamarinForms.Models;
using SampleXamarinForms.Views;
using SampleXamarinForms.ViewModels;

namespace SampleXamarinForms.Views
{	
	public partial class RequestPage : ContentPage
	{
		RequestViewModel _requestViewModel;

		public RequestPage()
		{
			InitializeComponent ();

			BindingContext = _requestViewModel = new RequestViewModel();
			Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
		}
	}
}

