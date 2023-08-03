
namespace AlohaAPIExample.Models
{
    public class OutGuest
    {
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double SecondaryTax { get; set; }
        public double Surcharge { get; set; }
        public double AdditionalCharge { get; set; }
        public double OrderModeCharge { get; set; }
        public double Gratuity { get; set; }
        public double Discount { get; set; }
        public List<int> ItemIds { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
