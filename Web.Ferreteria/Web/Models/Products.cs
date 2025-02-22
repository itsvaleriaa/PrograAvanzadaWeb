namespace Abstractions.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Photo { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public Guid? this_id_user_create { get; set; }
    }

    public class ProductsRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string? Photo { get; set; }
        public DateTime Created_at { get; set; }
        public Guid this_id_user_create { get; set; }
    }
}
