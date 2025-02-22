namespace Abstractions.Models
{
    public class People
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstLastName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PeopleRequest
    {
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
