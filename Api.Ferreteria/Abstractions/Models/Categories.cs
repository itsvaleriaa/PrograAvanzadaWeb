using Abstractions.Interfaces;

namespace Abstractions.Models
{
    public class Categories : IHasName
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class CategoriesRequest : IHasName
    {
        public string Name { get; set; }
    }
}
