namespace ShopApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    private  async void MenuItem_Clicked(object sender, EventArgs e)
    {
		var uri = new Uri("https://www.linkedin.com/in/balex17/");
		await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}
