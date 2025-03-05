using Abstractions.BC;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
    [Authorize(Roles = "1")]
    public class CategoriesController : Controller
    {
        private IConfiguracion _configuracion;
        private IList<Categories> categories { get; set; } = default!;
        private Categories category { get; set; }

        public CategoriesController(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        //[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerCategorias");
            var handler = new HttpClientHandler
            {
                // Acepta cualquier certificado (solo en desarrollo)
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var result = await client.SendAsync(request);
            try
            {
                result.EnsureSuccessStatusCode();

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var requestResult = await result.Content.ReadAsStringAsync();

                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        categories = JsonSerializer.Deserialize<List<Categories>>(requestResult, options);
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"Error de deserialización: {jsonEx.Message}");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
            }
            return View(categories);
        }

        [Authorize(Roles = "1")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CategoriesRequest category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "AgregarCategorias");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var result = await client.PostAsJsonAsync(endpoint, category);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(category);
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerCategoria");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, Id));
            var result = await client.SendAsync(request);
            try
            {
                result.EnsureSuccessStatusCode();

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var requestResult = await result.Content.ReadAsStringAsync();

                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        category = JsonSerializer.Deserialize<Categories>(requestResult, options);
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"Error de deserialización: {jsonEx.Message}");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Categories category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EditarCategorias");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var result = await client.PutAsJsonAsync(endpoint, category);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(category);
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EliminarCategorias");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, Id));
            var result = await client.SendAsync(request);
            try
            {
                result.EnsureSuccessStatusCode();

                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index", "Categories");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
            }
            return RedirectToAction("Index", "Categories");
        }
    }
}
