using Abstractions.BC;
using Abstractions.Models;
using Microsoft.Extensions.Configuration;

namespace BC
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuracion;

        public Configuracion(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public string GetUrlMethod(string section, string name)
        {
            var UrlBase = _configuracion.GetSection(section).Get<APIEndPoint>().BaseUrl;
            var Method = _configuracion.GetSection(section).Get<APIEndPoint>().Methods.Where(m => m.Nombre == name).FirstOrDefault().Valor;
            return $"{UrlBase}{Method}";
        }
    }
}
