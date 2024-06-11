 using ShopApp.Views;
using ShopApp.DataAccess;

namespace ShopApp;

public partial class App : Application
{
	public App(LoginPage loginPage, ShopOutDbContext context)
	{
		InitializeComponent();
        context.Database.EnsureCreated();
		var accessToken = Preferences.Get("accesstoken", string.Empty);
		if(string.IsNullOrEmpty(accessToken))
		{
			MainPage = loginPage;
		}
        else
        {
            MainPage = new AppShell();
        }       
	}
}
