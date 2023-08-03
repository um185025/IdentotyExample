using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class PesConsumerResponseData
    {
        public string maskedInternalId { get; set; }
        public PesStatus identifierStatus { get; set; }
        public PesStatus consumerStatus { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string internalId { get; set; }
        public List<PesProgramBalanceData> programBalances { get; set; }
    }
}
