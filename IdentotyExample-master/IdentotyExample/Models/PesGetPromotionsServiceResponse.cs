namespace AlohaAPIExample.Models
{
    public class PesGetPromotionsServiceResponse
    {
        public string providerResponseTime { get; set; }
        public string loyaltyBarcode { get; set; }
        public PesConsumerResponseData consumer { get; set; }
        public List<PesNotificationData> notifications { get; set; }
    }
}
