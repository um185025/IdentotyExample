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

        
    }
}
