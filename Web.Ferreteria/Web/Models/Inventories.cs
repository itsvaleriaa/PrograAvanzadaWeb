namespace Abstractions.Models
{
    public class Inventories
    {
        public int Id { get; set; }
        public Guid? IdProduct { get; set; }
        public Guid? IdSupplier { get; set; }
        public int? Stock { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public Guid? this_id_user_create { get; set; }
        // For Views
        public string? ProductName { get; set; }
        public string? SuppliersName { get; set; }
    }

    public class InventoriesRequest
    {
        public Guid IdProduct { get; set; }
        public Guid IdSupplier { get; set; }
        public int Stock { get; set; }
        public DateTime Created_at { get; set; }
        public Guid this_id_user_create { get; set; }
    }
}
