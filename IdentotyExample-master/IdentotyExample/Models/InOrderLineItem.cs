using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class InOrderLineItem
    {
        public int ItemLineNumber { get; set; }
        public int SalesItemId { get; set; }
        public int MenuItemId { get; set; }
        public string SpecialInstructions { get; set; }
        public string RecipientName { get; set; }
        public int Quantity { get; set; }
        public int NextModifierSequenceNumber { get; set; }
        public ItemOrderingMode ItemOrderingMode { get; set; }
        public double UnitPriceOverride { get; set; }
        public bool EnablePriceOverride { get; set; }
        public SectionType Section1Type { get; set; }
        public SectionType Section2Type { get; set; }
        public SectionType Section3Type { get; set; }
        public SectionType Section4Type { get; set; }
        public List<InOrderLineItemModifier> Modifiers { get; set; }
        public int ReferenceId { get; set; }
    }
}
