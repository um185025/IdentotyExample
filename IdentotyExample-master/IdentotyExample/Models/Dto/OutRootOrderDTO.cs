using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models.Dto
{
    public class OutRootOrderDTO
    {
        public OrderResultCodes ResultCode { get; set; }
        public object Order { get; set; }
        public int OrderId { get; set; }
        public object FailedItems { get; set; }
        public object FailedModifiers { get; set; }
        public object ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public double AmountDueAtSite { get; set; }
        public int LoyaltyResultCode { get; set; }
        public FinancialSummary FinancialSummary { get; set; }
    }
}
