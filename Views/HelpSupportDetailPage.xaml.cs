using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static Microsoft.Maui.ApplicationModel.Permissions;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage
{
    public HelpSupportDetailPage(HelpSupportDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
     
}