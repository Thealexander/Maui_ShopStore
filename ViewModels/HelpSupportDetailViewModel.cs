using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
//using static Android.Icu.Text.CaseMap;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    //Conexion a backend
    private readonly IConnectivity _connectivity;
    
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

    private CompraService _compraService;
    private readonly ShopOutDbContext _shopOutDbContext;

    public HelpSupportDetailViewModel(IConnectivity connectivity, CompraService compraService, ShopOutDbContext shopOutDbContext)
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);

        AddCommand = new Command(() =>
        {
            var compra = new Compra(
                ClienteId,
                ProductoSeleccionado.Id,
                Cantidad,
                ProductoSeleccionado.Nombre,
                ProductoSeleccionado.Precio,
                ProductoSeleccionado.Precio * Cantidad
                );
            Compras.Add(compra);
        },
        () => true
        );
        _connectivity = connectivity;
        _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
        _compraService = compraService;
        _shopOutDbContext = shopOutDbContext;
    }
    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task AddToCar()
    {
        /*
         var result = await _comprasService.SendData(Compras);
        if (result)
        {
            await Shell.Current.DisplayAlert("Message", "Se enviaron compras al backend", "ok");
        }
         */
        _shopOutDbContext.Database.EnsureCreated();
        foreach (var item in Compras)
        {
            _shopOutDbContext.Compras.Add(new CompraItem(
                item.ClientId,
                item.ProductId,
                item.Cantidad,
                item.ProductoPrecio
                ));
            await _shopOutDbContext.SaveChangesAsync();
            await Shell.Current.DisplayAlert("Message", "Se almaceno la compra en la db", "ok");
        }
    }
    private void _connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        AddToCarCommand.NotifyCanExecuteChanged();
    }
    private bool StatusConnection()
    {
       return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
    }
    public ICommand AddCommand { get; set; }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClienteId = clientId;
    }
    [RelayCommand]
    private void EliminarCompra(Compra compra)
    {
        Compras.Remove(compra);
    }
}




