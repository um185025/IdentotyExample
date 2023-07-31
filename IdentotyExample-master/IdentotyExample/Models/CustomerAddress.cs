using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class CustomerAddress
    {
        public int AddressId { get; set; }
        public AddressType AddressType { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; }
        public string DepartmentName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public Dictionary<object, object> ExtraData { get; set; }
        public string AddressNotes { get; set; }
    }
}
