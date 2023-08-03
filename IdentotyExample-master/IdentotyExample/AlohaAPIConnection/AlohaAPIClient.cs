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


    public async Task<Root> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5)
    {
        string url = $"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        Root root = JsonSerializer.Deserialize<Root>(serializedJson);
        return root;
    }

    public async Task<List<RootLL>> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType? orderMode, string? companyCode, int offset = 0, int limit = 5, bool includeAllSites = false)
    {

        var urlBuilder = new StringBuilder($"v1/NearbySites/{latitude}/{longitude}?&offset={offset}&limit={limit}&includeAllSites={includeAllSites}");
        if (orderMode != null)
            urlBuilder.Append($"&orderMode={orderMode}");
        if (companyCode != null)
            urlBuilder.Append($"&companyCode={companyCode}");
        string url = urlBuilder.ToString();

        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        List<RootLL> rootLLs = JsonSerializer.Deserialize<List<RootLL>>(serializedJson);
        return rootLLs;
    }

    public async Task<RootMenus> GetMenus(int siteId, DateTime? promiseTime, OrderModeType? orderMode, bool includeInvisible = false)
    {
        var urlBuilder = new StringBuilder($"v1/Menus/{siteId}?includeInvisible={includeInvisible}");
        if (orderMode != null)
            urlBuilder.Append($"&orderMode={orderMode}");
        if (promiseTime != null)
            urlBuilder.Append($"&promiseTime={promiseTime}");
        string url = urlBuilder.ToString();
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        RootMenus rootMenus = JsonSerializer.Deserialize<RootMenus>(serializedJson);
        return rootMenus;
    }

    public async Task<DateTime> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
    {
        string url = $"v1/Times/{siteId}/{orderMode}?noCache={noCache}";
        string endpoint = $"GET {url}";
        _logger.LogInformation(endpoint);

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        DateTime.TryParse(serializedJson, out DateTime dateTime);
        return dateTime;
    }

    public async Task<RootOrder> CreateOrder(Order order, int siteId, bool verbose = false)
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
        RootOrder rootOrder = JsonSerializer.Deserialize<RootOrder>(serializedJson);
        return rootOrder;
    }





}

