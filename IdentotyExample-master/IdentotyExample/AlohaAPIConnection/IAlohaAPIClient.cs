using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.AlohaAPIConnection
{
    public interface IAlohaAPIClient
    {
        Task<string> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5);
        Task<string> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001");
        Task<string> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup);
        Task<string> GetTime(int siteId, OrderModeType orderMode, bool noCache = false);
        Task<string> CreateOrder(Order order, int siteId, bool verbose = false);
    }
}
