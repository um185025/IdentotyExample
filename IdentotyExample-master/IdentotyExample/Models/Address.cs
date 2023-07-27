using System.ComponentModel.DataAnnotations;

namespace IdentotyExample.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string? City { get; set; }
        public string? StreetNumber { get; set; }
        public string? StreetName { get; set; }
        public string? ZipCode { get; set; }
        public User User { get; set; }
    }
}
