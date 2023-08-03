using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.AlohaAPIConnection
{
    public interface IAlohaAPIClient
    {
        Task<Root> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5);
        Task<List<RootLL>> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType? orderMode, string? companyCode, int offset = 0, int limit = 5, bool includeAllSites = false);
        Task<RootMenus> GetMenus(int siteId, DateTime? promiseTime, OrderModeType? orderMode, bool includeInvisible = false);
        Task<DateTime> GetTime(int siteId, OrderModeType orderMode, bool noCache = false);
        Task<RootOrder> CreateOrder(Order order, int siteId, bool verbose = false);
    }
}
