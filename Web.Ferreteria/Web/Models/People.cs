using System.ComponentModel;

namespace Abstractions.Models
{
    public class People
    {
        public int Id { get; set; }
        [DisplayName("Nombre")] public string? Name { get; set; }
        [DisplayName("Apellidos")] public string? FirstLastName { get; set; }
        [DisplayName("Ciudad")] public string? City { get; set; }
        [DisplayName("Dirección")] public string? Address { get; set; }
        [DisplayName("Número de Teléfono")] public int? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PeopleRequest
    {
        [DisplayName("Nombre")] public string Name { get; set; }
        [DisplayName("Apellidos")] public string FirstLastName { get; set; }
        [DisplayName("Ciudad")] public string City { get; set; }
        [DisplayName("Dirección")] public string Address { get; set; }
        [DisplayName("Número de Teléfono")] public int? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
