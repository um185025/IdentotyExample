using AlohaAPIExample.AlohaAPIConnection;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;

public class AlohaAPIClient : IAlohaAPIClient
{

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<AlohaAPIClient> _logger;

    public AlohaAPIClient(IHttpClientFactory httpClientFactory, ILogger<AlohaAPIClient> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    private HttpClient HttpClient { get => _httpClientFactory.CreateClient("AlohaAPIClient"); }


    public async Task<string> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5)
    {
        string url = $"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return serializedJson;
    }

    public async Task<string> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
    {
        string url = $"v1/NearbySites/{latitude}/{longitude}?orderMode={orderMode}&offset={offset}&limit={limit}&includeAllSites={includeAllSites}&companyCode={companyCode}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return serializedJson;
    }

    public async Task<string> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup)
    {
        string url = $"v1/Menus/{siteId}?promiseTime={promiseTime}&includeInvisible={includeInvisible}&orderMode={orderMode}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return serializedJson;
    }

    public async Task<string> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
    {
        string url = $"v1/Times/{siteId}/{orderMode}?noCache={noCache}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return serializedJson;
    }

    public async Task<string> CreateOrder(Order order, int siteId, bool verbose = false)
    {
        string url = $"v1/Orders/{siteId}?verbose={verbose}";
        string endpoint = $"PUT {url}";
        _logger.LogInformation(endpoint);
        string body = JsonSerializer.Serialize<Order>(order);
        HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
        using HttpResponseMessage response = await HttpClient.PutAsync(url, content);
        var resp = response.Content.ReadAsStringAsync();
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        return serializedJson;
    }





}

