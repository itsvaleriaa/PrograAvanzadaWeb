using Abstractions.BC;
using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private IConfiguracion _configuracion;
        private IList<Categories> categories { get; set; } = default!;

        public CategoriesController(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> Index()
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerCategorias");
            var handler = new HttpClientHandler
            {
                // Acepta cualquier certificado (solo en desarrollo)
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var cliente = new HttpClient(handler);
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                categories = JsonSerializer.Deserialize<List<Categories>>(resultado, opciones);
            }
            return View(categories);
        }
    }
}
