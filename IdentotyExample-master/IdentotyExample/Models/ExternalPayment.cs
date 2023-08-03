using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class ExternalPayment
    {
        public int OrderId { get; set; }
        public int SiteId { get; set; }
        public PaymentType Type { get; set; }
        public PaymentCardType CardType { get; set; }
        public int OrderOfProcessing { get; set; }
        public PaymentStatus Status { get; set; }
        public string MaskedCardNumber { get; set; }
        public double Amount { get; set; }
        public int PaymentResponse { get; set; }
        public string PaymentReference { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string PaymentAuthCode { get; set; }
        public string PaymentCancelReference { get; set; }
        public string PaymentCancelReferenceNumber { get; set; }
        public int PaymentCancelResponse { get; set; }
        public DateTime PaymentAuthorizationTimestamp { get; set; }
        public DateTime PaymentCancellationTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public bool IsCancelAttempted { get; set; }
        public ProcessingType ProcessingType { get; set; }
        public P2PEComboType P2PECombo { get; set; }
        public TokenDetails FreedomPayTokenDetails { get; set; }
    }
}
