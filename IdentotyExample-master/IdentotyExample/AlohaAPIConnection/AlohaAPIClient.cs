using AlohaAPIExample.AlohaAPIConnection;
using AlohaAPIExample.Models.Dto;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public AlohaAPIClient(IHttpClientFactory httpClientFactory, ILogger<AlohaAPIClient> logger, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _mapper = mapper;
    }

    private HttpClient HttpClient { get => _httpClientFactory.CreateClient("AlohaAPIClient"); }


    public async Task<OutRootDTO> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5)
    {
        string url = $"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}";

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        Root root = JsonSerializer.Deserialize<Root>(serializedJson);
        OutRootDTO result = _mapper.Map<OutRootDTO>(root);
        return result;
    }

    public async Task<List<OutRootLLDTO>> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, OrderModeType? orderMode, string? companyCode, int offset = 0, int limit = 5, bool includeAllSites = false)
    {

        var urlBuilder = new StringBuilder($"v1/NearbySites/{latitude}/{longitude}?&offset={offset}&limit={limit}&includeAllSites={includeAllSites}");
        if (orderMode != null)
            urlBuilder.Append($"&orderMode={orderMode}");
        if (companyCode != null)
            urlBuilder.Append($"&companyCode={companyCode}");
        string url = urlBuilder.ToString();

        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        List<RootLL> rootLLs = JsonSerializer.Deserialize<List<RootLL>>(serializedJson);
        List<OutRootLLDTO> result = _mapper.Map<List<OutRootLLDTO>>(rootLLs);
        return result;
    }

    public async Task<OutRootMenusDTO> GetMenus(int siteId, DateTime? promiseTime, OrderModeType? orderMode, bool includeInvisible = false)
    {
        var urlBuilder = new StringBuilder($"v1/Menus/{siteId}?includeInvisible={includeInvisible}");
        if (orderMode != null)
            urlBuilder.Append($"&orderMode={orderMode}");
        if (promiseTime != null)
            urlBuilder.Append($"&promiseTime={promiseTime}");
        string url = urlBuilder.ToString();
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        RootMenus rootMenus = JsonSerializer.Deserialize<RootMenus>(serializedJson);
        OutRootMenusDTO result = _mapper.Map<OutRootMenusDTO>(rootMenus);
        return result;
    }

    public async Task<DateTime> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
    {
        string url = $"v1/Times/{siteId}/{orderMode}?noCache={noCache}";
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        DateTime.TryParse(serializedJson, out DateTime dateTime);
        return dateTime;
    }

    public async Task<OutRootOrderDTO> CreateOrder(InOrderDTO inOrderDTO, int siteId, bool verbose = false)
    {
        string url = $"v1/Orders/{siteId}?verbose={verbose}";
        Order order = _mapper.Map<Order>(inOrderDTO);
        string orderString = JsonSerializer.Serialize(order);
        string body = JsonSerializer.Serialize(order);
        HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
        using HttpResponseMessage response = await HttpClient.PutAsync(url, content);
        var resp = response.Content.ReadAsStringAsync();
        string serializedJson = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        RootOrder rootOrder = JsonSerializer.Deserialize<RootOrder>(serializedJson);
        OutRootOrderDTO result = _mapper.Map<OutRootOrderDTO>(rootOrder);
        return result;
    }





}

