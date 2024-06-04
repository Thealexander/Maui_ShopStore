using ShopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services;

    public  class ComprasService
    {
    private HttpClient client;
    public ComprasService(HttpClient client)
    {
        this.client = client;
    }
    public  async Task<bool> SendData(IEnumerable<Compra> compras)
    {
        var uri = "http://192.168.1.13:5000/api/Compra";
        var body = new
        {
            data = compras
        };
        var resultado = await client.PostAsJsonAsync(uri, body);
        return resultado.IsSuccessStatusCode;
            }

    }

