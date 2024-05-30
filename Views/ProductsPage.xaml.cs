using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

        var database = new ShopDbContext();
        products.ItemsSource = database.Products;

    }
}