using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;

namespace ShopApp.ViewModels
{
    public partial class LoginViewModel : ViewModelGlobal
    {
        private readonly IConnectivity _connectivity;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        private readonly SecurityService _securityService;

        public LoginViewModel(IConnectivity connectivity, SecurityService securityService)
        {
            _connectivity = connectivity ?? throw new ArgumentNullException(nameof(connectivity));
            _securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
            _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
        }

        [RelayCommand(CanExecute = nameof(StatusConnection))]
        private async Task LoginMethod()
        {
            Console.WriteLine($"Attempting login with Email: {Email} and Password: {Password}");
            var resultado = await _securityService.Login(Email, Password);
            Console.WriteLine($"Login result: {resultado}");

            if (resultado)
            {
                Console.WriteLine("Login successful, navigating to AppShell.");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Console.WriteLine("Login failed, showing alert.");
                await Application.Current.MainPage.DisplayAlert("Mensaje", "Ingresaste credenciales erroneas", "Aceptar");
            }
        }

        private void _connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            LoginMethodCommand.NotifyCanExecuteChanged();
        }

        private bool StatusConnection()
        {
            return _connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
