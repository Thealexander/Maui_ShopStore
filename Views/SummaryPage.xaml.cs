using ShopApp.ViewModels;
using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class SummaryPage : ContentPage
{
	public SummaryPage(SummaryViewmodel viewmodel)
	{
        InitializeComponent();
		BindingContext = viewmodel;
	}

  }