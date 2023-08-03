using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class OrderDiscount
    {
        public int ItemLineNumber { get; set; }
        public int DiscountId { get; set; }
        public OrderDiscountType MyProperty { get; set; }
        public double Amount { get; set; }
        public DiscountStatus DiscountStatus { get; set; }
        public int DiscountIndex { get; set; }
        public OrderDiscountSource OrderDiscountSource { get; set; }
    }
}
