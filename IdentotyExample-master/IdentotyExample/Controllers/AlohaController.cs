using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Controllers
{
    public class AlohaController : Controller
    {
        private readonly AlohaAPIClient _client;
        private string credentials;

        public AlohaController()
        {
            _client = new AlohaAPIClient();
            string username = "api-demo@ds.com";
            string password = "DigitalNCRDigital123@";
            credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
     

            _client.AddDefaultRequestHeaders(headers =>
            {
                headers.Add("X-Api-CompanyCode", "DLEC001");
                headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            });
        }

        [HttpGet]
        [Route("GetNearbySitesBySearchTerm")]
        public async Task<ActionResult> GetNearbySitesBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetAsync($"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}");
            Root root = JsonSerializer.Deserialize<Root>(response);
            return Ok(root);
        }

        [HttpGet]
        [Route("GetFirstNearbySiteBySearchTerm")]
        public async Task<ActionResult> GetFirstNearbySiteBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetAsync($"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}");
            Root root = JsonSerializer.Deserialize<Root>(response);
            if(root.NearbySites != null)
                return Ok(root.NearbySites[0]);
            else return NotFound("Nearby sites not found.");
        }


        [HttpGet]
        [Route("GetNearbySitesByLongitudeAndLatitude")]
        public async Task<ActionResult> GetNearbySitesByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = 0, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "")
        {
            var response = await _client.GetAsync($"v1/NearbySites/{latitude}/{longitude}?orderMode={orderMode}&offset={offset}&limit={limit}&includeAllSites={includeAllSites}&companyCode={companyCode}");
            List<RootLL> root = JsonSerializer.Deserialize<List<RootLL>>(response); 
            return Ok(root);
        }

        [HttpGet]
        [Route("GetNearbySitesByLongitudeAndLatitude")]
        public async Task<ActionResult> GetNearbySitesByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = 0, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "")
        {
            var response = await _client.GetAsync($"v1/NearbySites/{latitude}/{longitude}?orderMode={orderMode}&offset={offset}&limit={limit}&includeAllSites={includeAllSites}&companyCode={companyCode}");
            List<RootLL> root = JsonSerializer.Deserialize<List<RootLL>>(response);
            return Ok(root);
        }

        [HttpGet]
        [Route("GetMenus")]
        public async Task<ActionResult> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = 0)
        {
            var response = await _client.GetAsync($"v1/Menus/{siteId}?promiseTime={promiseTime}&includeInvisible={includeInvisible}&orderMode={orderMode}");
            RootMenus root = JsonSerializer.Deserialize<RootMenus>(response);
            return Ok(root);
        }

        [HttpGet]
        [Route("GetTime")]
        public async Task<ActionResult> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            var response = await _client.GetAsync($"v1/Times/{siteId}/{orderMode}?noCache={noCache}");
            return Ok(response);
        }

        private Order CreateOrder()
        {
            OrderCustomer orderCustomer = new OrderCustomer();
            orderCustomer.id = "2";
            orderCustomer.EMail = "urosmitrovi@gmail.com";
            orderCustomer.FirstName = "Uros";
            orderCustomer.LastName = "Mitrovic";
            Order order = new Order();
            order.SiteId = 1;
            order.OrderId = 1;
            order.Customer = orderCustomer;
            order.Channel = "Unknown";
            order.OrderMode = OrderModeType.DineIn;
            order.PaymentMode = PaymentMode.PaymentDeferred;

            return order;
        }

        [HttpPut]
        [Route("CreateOrder")]
        public async Task<ActionResult> CreateOrder(int siteId, bool verbose = false)
        {
            string body = JsonSerializer.Serialize(CreateOrder());

            var response = await _client.PutAsync($"v1/Orders/{siteId}?verbose={verbose}", body);

            return Ok(response);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
