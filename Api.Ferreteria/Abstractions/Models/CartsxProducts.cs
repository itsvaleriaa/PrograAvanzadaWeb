namespace Abstractions.Models
{
    public class CartsxProducts
    {
        public Guid IdCart { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        // For Views
        public string? ProductName { get; set; }
    }
}
