using System.ComponentModel;

namespace Abstractions.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [DisplayName("Nombre de la categoria")] public string? Name { get; set; }
    }

    public class CategoriesRequest
    {
        [DisplayName("Nombre de la categoria")] public string Name { get; set; }
    }
}
