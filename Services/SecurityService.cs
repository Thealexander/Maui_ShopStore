using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopApp.Models.Backend.Login;
using ShopApp.Models.Config;
using System.Text;

namespace ShopApp.Services
{
    public class SecurityService
    {
        private HttpClient client;
        private Settings settings;

        public SecurityService(HttpClient client, IConfiguration configuration)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
        }

        public async Task<bool> Login(string email, string password)
        {
            var url = $"{settings.UrlBase}/api/usuario/login";
            var loginRequest = new LoginRequest
            {
                Email = email,
                Password = password
            };

            try
            {
                var json = JsonConvert.SerializeObject(loginRequest);
                Console.WriteLine($"Request JSON: {json}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Login failed with status code: {response.StatusCode}");
                    return false;
                }

                var jsonResultado = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response JSON: {jsonResultado}");

                if (string.IsNullOrEmpty(jsonResultado))
                {
                    Console.WriteLine("Login response content is empty");
                    return false;
                }

                var resultado = JsonConvert.DeserializeObject<UsuarioResponse>(jsonResultado);
                if (resultado == null)
                {
                    Console.WriteLine("Failed to deserialize login response");
                    return false;
                }

                Preferences.Set("accesstoken", resultado.Token);
                Preferences.Set("userid", resultado.Id);
                Preferences.Set("email", resultado.Email);
                Preferences.Set("nombre", $"{resultado.Nombre} {resultado.Apellido}");
                Preferences.Set("telefono", resultado.Telefono);
                Preferences.Set("username", resultado.UserName);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login exception: {ex.Message}");
                return false;
            }
        }
    }
}
