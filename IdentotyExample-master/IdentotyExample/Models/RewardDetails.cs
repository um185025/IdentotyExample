using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.Models
{
    public class RewardDetails
    {
        public bool AutoRejectReward { get; set; }
        public List<CheckItemDiscount> CheckItemDiscounts { get; set; }
        public string CheckText { get; set; }
        public int DiscountId { get; set; }
        public string DiscountText { get; set; }
        public bool DiscountUpToDiscountAmount { get; set; }
        public int HstRewardProgramId { get; set; }
        public int Iteration { get; set; }
        public bool PrintOnVoucher { get; set; }
        public int RewardProgramId { get; set; }
        public AlohaRewardType RewardType { get; set; }
        public int TierId { get; set; }
        public string TierName { get; set; }
        public string VoucherText1 { get; set; }
    }
}
