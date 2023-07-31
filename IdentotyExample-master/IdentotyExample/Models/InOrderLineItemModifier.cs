namespace AlohaAPIExample.Models
{
    public class InOrderLineItemModifier
    {
        public int SequenceNumber { get; set; }
        public int ItemOptionGroupId { get; set; }
        public int SalesItemOptionId { get; set; }
        public ModifierAction Action { get; set; }
        public ModifierAction DefaultAction { get; set; }
        public int ItemLineNumber { get; set; }
        public int ParentSequenceNumber { get; set; }
        public int Quantity { get; set; }
        public bool IsOnEntireItem { get; set; }
        public bool IsOnSection1 { get; set; }
        public bool IsOnSection2 { get; set; }
        public bool IsOnSection3 { get; set; }
        public bool IsOnSection4 { get; set; }
        public int FreeQuantity { get; set; }
        public double UnitPriceOverride { get; set; }
        public bool EnablePriceOverride { get; set; }
        public List<InOrderLineItemModifier> Modifiers { get; set; }
    }
}
