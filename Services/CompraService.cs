using Microsoft.Extensions.Configuration;
using ShopApp.DataAccess;
using ShopApp.Models.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services;

    public  class CompraService
    {
    private HttpClient client;
    private Settings settings;
    public CompraService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
        settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
    }
    public  async Task<bool> SendData(IEnumerable<Compra> compras)
    {
        var uri = $"{settings.UrlBase}/api/compra";
        var body = new
        {
            data = compras
        };
        var resultado = await client.PostAsJsonAsync(uri, body);
        return resultado.IsSuccessStatusCode;
            }

    }

