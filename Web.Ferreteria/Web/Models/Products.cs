using System.ComponentModel;

namespace Abstractions.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        [DisplayName("Nombre")] public string? Name { get; set; }
        [DisplayName("Descripción")] public string? Description { get; set; }
        [DisplayName("Precio")] public float? Price { get; set; }
        [DisplayName("Foto")] public byte[]? Photo { get; set; }
        [DisplayName("Fecha creación")] public DateTime? Created_at { get; set; }
        [DisplayName("Fecha de última actualización")] public DateTime? Updated_at { get; set; }
        public string? this_id_user_create { get; set; }
    }

    public class ProductsRequest
    {
        [DisplayName("Nombre")] public string Name { get; set; }
        [DisplayName("Descripción")] public string Description { get; set; }
        [DisplayName("Precio")] public float Price { get; set; }
        [DisplayName("Foto")] public byte[]? Photo { get; set; }
        [DisplayName("Fecha de creación")] public DateTime Created_at { get; set; }
        public string? this_id_user_create { get; set; }
    }
}
