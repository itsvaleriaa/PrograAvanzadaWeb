using Abstractions.BC;
using Abstractions.Models;
using BC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguracion _configuracion;
        private Register register { get; set; } = default!;
        private Login login { get; set; } = default!;
        public Token token { get; set; } = default!;

        public AccountController(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (register.PasswordHash != register.ConfirmPassword)
            {
                ModelState.AddModelError("registro.ConfirmPassword", "Las contraseñas no coinciden.");
                return View(register);
            }

            int idPerson = await AddPerson(new PeopleRequest
            {
                Name = register.Name,
                FirstLastName = register.FirstLastName,
                City = register.City,
                Address = register.Address,
                PhoneNumber = int.Parse(register.PhoneNumber)
            });
            if (idPerson != null && idPerson != 0)
            {
                var hash = Authentication.GenerateHash(register.PasswordHash);
                register.Hash = Authentication.GetHash(hash);

                string endpoint = _configuracion.GetUrlMethod("SecurityApiEndPoints", "Registro");
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
                var client = new HttpClient(handler);
                try
                {
                    var result = await client.PostAsJsonAsync(endpoint, new RegisterUser
                    {
                        idPerson = idPerson,
                        email = register.Email,
                        passwordHash = register.Hash,
                        created_At = DateTime.UtcNow
                    });
                    result.EnsureSuccessStatusCode();
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "EliminarPersonas");
                        var request = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, idPerson));
                        var resultP = await client.SendAsync(request);
                        try
                        {
                            resultP.EnsureSuccessStatusCode();

                            if (resultP.StatusCode == System.Net.HttpStatusCode.NoContent)
                            {
                                return RedirectToAction("Registrarse", "Account");
                            }
                        }
                        catch (HttpRequestException httpEx)
                        {
                            Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                            return View(register);
                        }
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"Error en la request HTTP: {httpEx.Message}");
                    return View(register);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                    return View(register);
                }
            }
            return View(register);
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var hash = Authentication.GenerateHash(login.Password);
            login.Hash = Authentication.GetHash(hash);

            string endpoint = _configuracion.GetUrlMethod("SecurityApiEndPoints", "IniciarSesion");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var result = await client.PostAsJsonAsync<Login>(endpoint, new Login
                {
                    Email = login.Email,
                    Hash = login.Hash
                });
                result.EnsureSuccessStatusCode();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        token = JsonSerializer.Deserialize<Token>(result.Content.ReadAsStringAsync().Result, options);

                        if (token.SuccessfulValidation)
                        {
                            JwtSecurityToken? jwtToken = Authentication.readToken(token.AccessToken);
                            var claims = Authentication.GenerateClaims(jwtToken, token.AccessToken);
                            await SetAuthentication(claims);
                            return RedirectToAction("Index", "Home");
                        }
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
                return View(register);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error inesperado: {ex.Message}");
                return View(register);
            }
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        private async Task<int> AddPerson(PeopleRequest person)
        {
            person.CreatedAt = DateTime.UtcNow;

            string endpoint = _configuracion.GetUrlMethod("ApiEndPoints", "CrearPersonas");
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            try
            {
                var response = await client.PostAsJsonAsync(endpoint, person);
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(content, out int resultId))
                        return resultId;
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
            return 0;
        }

        private async Task SetAuthentication(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}
