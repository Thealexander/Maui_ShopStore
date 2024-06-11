using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModels;

    public partial class SummaryViewmodel: ViewModelGlobal
    {
    [ObservableProperty]
    int visitas;
    [ObservableProperty]
    int clients;
    [ObservableProperty]
    decimal total;
    [ObservableProperty]
    int totalProducts;

    public SummaryViewmodel(ShopOutDbContext shopOutDbContext)
    {
        try
        {
            Visitas = shopOutDbContext.Compras
                .AsEnumerable()
                .DistinctBy(s => s.ClientId)
                .Count();

            using (var db = new ShopDbContext())
            {
                Clients = db.Clients.Count();
            }

            Total = shopOutDbContext.Compras
                .AsEnumerable()
                .Sum(s => s.Cantidad * s.Precio);

            TotalProducts = shopOutDbContext.Compras
                .Sum(s => s.Cantidad);
        }
        catch (Exception ex)
        {
            // Manejo de la excepción,
            Console.WriteLine($"Error al acceder a la tabla Compras: {ex.Message}");
        }

    }
}

