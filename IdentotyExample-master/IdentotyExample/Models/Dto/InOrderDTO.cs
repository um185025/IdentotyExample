using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models.Dto
{
    public class InOrderDTO
    {
        public int InOrderSiteId { get; set; }
        //public int OrderId { get; set; }
        //public int DesignId { get; set; }
        public DateTime PromiseDateTime { get; set; }
        public List<InInOrderLineItemDTO> LineItems { get; set; }
        public List<ComboItem> ComboItems { get; set; }
        public OrderModeType OrderMode { get; set; }
        //public bool UpdateTimeDisabled { get; set; }
        public PaymentMode PaymentMode { get; set; }
       // public OrderSourceType OrderSource { get; set; }
        //public DestinationType Destination { get; set; }
        //public bool ShouldManualRelease { get; set; }
        //public int TaxJurisdictionId { get; set; }
        public InCustomerDTO Customer { get; set; }
        public CustomerAddress CustomerAddressForOrder { get; set; }
       // public string SpecialInstructions { get; set; }
        //public string LoyaltyNumber { get; set; }
       // public int CompId { get; set; }
        //public List<InComp> Comps { get; set; }
        public List<Guest> Guests { get; set; }
        //public int ReferenceNumber { get; set; }
        //public string ExternalOrderId { get; set; }
        //public bool AssignLoyalty { get; set; }
        //public double DeliveryFeeAmount { get; set; }
       // public int? QuoteId { get; set; }
        public string Channel { get; set; }
        //public bool DineIn { get; set; }
        //public int TableNumber { get; set; }
        //public int TableId { get; set; }
    }
}
