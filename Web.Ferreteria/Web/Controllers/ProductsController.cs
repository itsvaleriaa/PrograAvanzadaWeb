using Abstractions.BC;
using Abstractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Web.Controllers
{
    [Authorize(Roles = "1")]
    public class ProductsController : Controller
    {
        private IConfiguracion _configuracion;
        private IList<Products> products { get; set; } = default!;
        private Products product { get; set; }
        private ProductsRequest product_request { get; set; }
        public ProductsController(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerProductos");
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
        public async Task<IActionResult> Crear(ProductsRequest product_request, IFormFile? photo)
        {
            if (photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    product_request.Photo = memoryStream.ToArray();
                }
            }
            else
            {
                product_request.Photo = null;
            }
            product_request.Created_at = DateTime.Now;
            product_request.this_id_user_create = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                return View(product_request);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "CrearProductos");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var tokenClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Token");
                if (tokenClaim != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenClaim.Value);
                }
                var result = await client.PostAsJsonAsync(endpoint, product_request);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Products");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(product_request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(product_request);
            }
            return View(product_request);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(Guid Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "ObtenerProducto");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
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
                        product = JsonSerializer.Deserialize<Products>(requestResult, options);
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
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Products product, IFormFile? photo)
        {
            if (photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    product.Photo = memoryStream.ToArray();
                }
            }
            else
            {
                product.Photo = null;
            }
            product.Updated_at = DateTime.Now;
            product.this_id_user_create = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EditarProductos");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            try
            {
                var result = await client.PutAsJsonAsync(endpoint, product);
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index", "Products");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                return View(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(product);
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EliminarProductos");
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
                    return RedirectToAction("Index", "Products");
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
            return RedirectToAction("Index", "Products");
        }
    }
}
