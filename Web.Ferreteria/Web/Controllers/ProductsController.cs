using Abstractions.BC;
using Abstractions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private IConfiguracion _configuracion;
        private IList<Products> products { get; set; } = default!;
        private Products product { get; set; }
        public ProductsController(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> Index()
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerPersonas");
            var handler = new HttpClientHandler
            {
                // Acepta cualquier certificado (solo en desarrollo)
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var tokenClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Token");
            if (tokenClaim != null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenClaim.Value);
            }
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
                        products = JsonSerializer.Deserialize<List<Products>>(requestResult, options);
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
            return View(products);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PeopleRequest person)
        {
            person.CreatedAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "CrearPersonas");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var result = await client.PostAsJsonAsync(endpoint, person);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index", "People");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(person);
            }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerPersona");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, Id));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
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
                        person = JsonSerializer.Deserialize<People>(requestResult, options);
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
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(People person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EditarPersonas");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            try
            {
                var result = await client.PutAsJsonAsync(endpoint, person);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index", "People");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(person);
            }
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EliminarPersonas");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, Id));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var result = await client.SendAsync(request);
            try
            {
                result.EnsureSuccessStatusCode();

                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index", "People");
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
            return RedirectToAction("Index", "People");
        }
    }
}
