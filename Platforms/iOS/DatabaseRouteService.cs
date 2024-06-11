using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services;

public class DatabaseRouteService : IDatabaseRouteService
{
    public string Get(string archiveName)
    {
        var dirRoute = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(dirRoute, archiveName);
    }
}

