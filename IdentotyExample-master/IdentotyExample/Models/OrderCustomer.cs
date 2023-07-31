using AlohaAPIExample.Models;

public class OrderCustomer
    {
        public string id { get; set; }
        public Guid CustomerId { get; set; }
        public string EMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string VoicePhone { get; set; }
        public string VoicePhoneExtension { get; set; }
        public string DepartmentName { get; set; }
        public string AltPhone { get; set; }
        public string AltPhoneExtension { get; set; }
        public int? FavoriteSiteId { get; set; }
        public List<int>? FavoriteSiteIds { get; set; }
        public int? LoyaltyCardNumber { get; set; }
        public string? SecondaryEmailAddress { get; set; }
        public List<CustomerAddress>? Addresses { get; set; }
        public DateTime? Birthday { get; set; }
        public int? LoyaltyZipCode { get; set; }
    }
