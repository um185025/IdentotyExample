using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class ComboItem
    {
        public int PromoId { get; set; }
        public PromoType PromoType { get; set; }
        public double Price { get; set; }
        public string ComboName { get; set; }
        public bool IsVisible { get; set; }
        public List<OrderWebSalesGroup> WebSalesGroupLineItems { get; set; }

    }
}
