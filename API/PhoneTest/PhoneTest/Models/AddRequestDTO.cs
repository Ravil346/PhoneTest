﻿namespace PhoneTest.Models
{
    public class AddContactRequestDTO
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public bool Faforite { get; set; }
    }
}
