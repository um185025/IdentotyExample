using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class ExternalLineItem
    {
        public int LineItemNumber { get; set; }
        public int SalesItemId { get; set; }
        public int MenuItemId { get; set; }
        public int CompId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string SpecialInstructions { get; set; }
        public string RecipientName { get; set; }
        public ItemOrderingMode ItemOrderingMode { get; set; }
        public SectionType Section1Type { get; set; }
        public SectionType Section2Type { get; set; }
        public SectionType Section3Type { get; set; }
        public SectionType Section4Type { get; set; }
        public List<ExternalLineItemModifier> Modifiers { get; set; }
        public double UnitPrice { get; set; }
        public double ExtendedPrice { get; set; }
        public int Quantity { get; set; }
        public int NextModifierSequenceNumber { get; set; }
        public int PostItemId { get; set; }
        public double CompValue { get; set; }
        public bool IsVisible { get; set; }
        public bool CanBeReordered { get; set; }
    }
}
