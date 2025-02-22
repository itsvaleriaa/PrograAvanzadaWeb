namespace Abstractions.Models
{
    public class APIEndPoint
    {
        public string? BaseUrl { get; set; }
        public IEnumerable<Metodo>? Methods { get; set; }
    }
    public class Metodo
    {
        public string? Nombre { get; set; }
        public string? Valor { get; set; }
    }
}
