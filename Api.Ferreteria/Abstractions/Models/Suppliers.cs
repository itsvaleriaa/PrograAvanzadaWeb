﻿using Abstractions.Interfaces;

namespace Abstractions.Models
{
    public class Suppliers : IHasName, IHasCity, IHasAddress, IHasEmail
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Representative { get; set; }
        public Guid? This_id_user_create { get; set; }
    }

    public class SuppliersRequest : IHasName, IHasCity, IHasAddress, IHasEmail
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Representative { get; set; }
        public Guid This_id_user_create { get; set; }
    }
}
