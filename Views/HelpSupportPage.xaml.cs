using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage(HelpSupportViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

