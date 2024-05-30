﻿using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;
//using static Android.Icu.Text.CaseMap;

namespace ShopApp.ViewModels;


public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    private ObservableCollection<Compra> compras = new ObservableCollection<Compra>();

    [ObservableProperty]
    private int clienteId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product productoSeleccionado;

    [ObservableProperty]
    private int cantidad;

    public HelpSupportDetailViewModel()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);

        AddCommand = new Command(() =>
        {
            var compra = new Compra(ClienteId, ProductoSeleccionado.Id, Cantidad);
            Compras.Add(compra);
        },
        () => true
        );
    }
    public ICommand AddCommand { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClienteId = clientId;
    }
}

