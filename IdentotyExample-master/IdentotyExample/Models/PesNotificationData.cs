namespace AlohaAPIExample.Models
{
    public class PesNotificationData
    {
        public int maxRewardApprovals { get; set; }
        public int maxItemsWithPurchase { get; set; }
        public List<PesRewardApprovalBasicData> pesRewardApprovals { get; set; }
        public List<PesItemsWithPurchaseBasicData> itemsWithPurchase { get; set; }
        public List<PesProximityNotificationBasicData> proximity { get; set; }
        public List<PesRedeemableLoyaltyProgram> redeemableLoyaltyPrograms { get; set; }
        public List<PesOtherNotificationBasicData> otherNotifications { get; set; }
        public List<PesRecommendationsBasicData> recommendations { get; set; }
        public List<PesCustomerPromptRequest> prompts { get; set; }
    }
}
