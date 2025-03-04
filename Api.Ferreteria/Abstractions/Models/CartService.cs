namespace Abstractions.Models
{
    public class CartService
    {
        public Guid IdCart { get; set; }
        public int IdService { get; set; }
        // For views
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ServiceSchedule { get; set; }
        public float? ServicePrice { get; set; }
    }
}
