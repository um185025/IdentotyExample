namespace AlohaAPIExample.Models
{
    public class CheckItemDiscount
    {
        public int ItemLineNumber { get; set; }
        public int PosSalesItemId { get; set; }
        public int PosModifierId { get; set; }
        public double Discount { get; set; }
        public string DiscountedItemName { get; set; }
    }
}
