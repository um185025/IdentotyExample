using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class ExternalOrder
    {
        public int SiteId { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int PromoId { get; set; }
        public int DesignId { get; set; }
        public OrderModeType OrderMode { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PromiseDateTime { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public OrderCustomer Customer { get; set; }
        public CustomerAddress CustomerAddressForOrder { get; set; }
        public List<ExternalLineItem> LineItems { get; set; }
        public double SubTotalAmount { get; set; }
        public double TotalSubchargeAmount { get; set; }
        public double TaxAmount { get; set; }
        public double PaymentAmount { get; set; }
        public double TotalAmount { get; set; }
        public double BalanceDueAmount { get; set; }
        public string LoyaltyCardNumber { get; set; }
        public List<RewardDetails> LoyaltyRewards { get; set; }
        public OrderSourceType OrderSource { get; set; }
        public DestinationType Destination { get; set; }
        public int NextItemLineNumber { get; set; }
        public string SpecialInstructions { get; set; }
        public Guid SubmitCommandId { get; set; }
        public int SubmitOrderNumber { get; set; }
        public int HumanReadableSubmitOrderNumber { get; set; }
        public string SubmitMessage { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int CompId { get; set; }
        public List<ExternalPosComp> AppliedComps { get; set; }
        public double CompValue { get; set; }
        public string CompName { get; set; }
        public double DeliveryFeeAmount { get; set; }
        public int TaxJurisdictionId { get; set; }
        public int SubmitOrderId { get; set; }
        public bool IsFailover { get; set; }
        public int ReferenceNumber { get; set; }
        public string ExternalOrderId { get; set; }
        public List<ComboItem> ComboItems { get; set; }
        public List<OutGuest> Guests { get; set; }
        public double SVCAmount { get; set; }
        public List<ExternalPayment> Payments { get; set; }
        public int NextOrderOfProcessing { get; set; }
        public string SiteNotes { get; set; }
        public bool IsVisible { get; set; }
        public double DiscountTotal { get; set; }
        public OrderMetadata Metadata { get; set; }
        public double ComputedDiscount { get; set; }
        public List<OrderDiscount> OrderDiscounts { get; set; }
        public int SavedOrderId { get; set; }
        public PesGetPromotionsServiceResponse PromotionsServiceResponse { get; set; }
    }
}
