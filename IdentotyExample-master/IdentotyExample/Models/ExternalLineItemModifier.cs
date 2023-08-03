using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class ExternalLineItemModifier
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
        public bool IsVisible { get; set; }
        public bool CanBeReordered { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double ExtendedPrice { get; set; }
        public int PosModifierGroupId { get; set; }
        public int PosModifierId { get; set; }
        public OrderLineItemStatus Status { get; set; }
        public List<ExternalLineItemModifier> Modifiers { get; set; }
    }
}
