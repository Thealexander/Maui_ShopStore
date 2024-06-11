namespace ShopApp.Services;

public class DatabaseRouteService : IDatabaseRouteService
{
    public string Get(string archiveName)
    {
        var dirRoute = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(dirRoute, archiveName);
    }
}

