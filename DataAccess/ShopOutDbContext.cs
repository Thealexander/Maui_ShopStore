using Microsoft.EntityFrameworkCore;
using ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess;

    public class ShopOutDbContext : DbContext
    {
    public DbSet<CompraItem> Compras { get; set; }
    public readonly IDatabaseRouteService _databaseRoute;

    public ShopOutDbContext( IDatabaseRouteService databaseRoute)
    {
        _databaseRoute = databaseRoute;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         var cn=  $"Filename={_databaseRoute.Get("shopdatabase.db")}";
         optionsBuilder.UseSqlite(cn);
    }
}
 public record CompraItem(int ClientId,int ProductId, int Cantidad, decimal Precio)
{
    public int Id { get; set; }
}
