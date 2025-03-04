namespace Abstractions.Models
{
    public class Carts
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime? DateCreated { get; set; }
    }

    public class CartsRequest
    {
        public Guid IdUser { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
