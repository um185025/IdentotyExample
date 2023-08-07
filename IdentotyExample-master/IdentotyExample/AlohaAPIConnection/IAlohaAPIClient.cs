using AlohaAPIExample.Models.Dto;
using static IdentotyExample.Enums.Enums;

namespace AlohaAPIExample.AlohaAPIConnection
{
    public interface IAlohaAPIClient
    {
        Task<OutRootDTO> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5);
        Task<List<OutRootLLDTO>> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType? orderMode, string? companyCode, int offset = 0, int limit = 5, bool includeAllSites = false);
        Task<OutRootMenusDTO> GetMenus(int siteId, DateTime? promiseTime, OrderModeType? orderMode, bool includeInvisible = false);
        Task<DateTime> GetTime(int siteId, OrderModeType orderMode, bool noCache = false);
        Task<OutRootOrderDTO> CreateOrder(InOrderDTO order, int siteId, bool verbose = false);
    }
}
