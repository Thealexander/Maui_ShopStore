using Android.App;
using Android.Runtime;
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]// permite conexiones remotas
namespace ShopApp;

[Application(UsesCleartextTraffic = true)]// aca se configura para las conexiones remotas
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
