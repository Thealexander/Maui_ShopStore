using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
	public ProductDetailPage()
	{
		InitializeComponent();
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"].ToString());
        var producto = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        container.Children.Add(new Label { Text = producto.Nombre });
        container.Children.Add(new Label { Text = producto.Descripcion });
        container.Children.Add(new Label { Text = producto.Precio.ToString() });

    }
}