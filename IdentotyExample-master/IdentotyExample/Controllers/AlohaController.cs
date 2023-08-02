using AlohaAPIExample.Models;
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

        public AlohaController(AlohaAPIClient client)
        {
            _client = client;
            
        }

        [HttpGet]
        [Route("GetNearbySitesBySearchTerm")]
        public async Task<ActionResult> GetNearbySitesBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            Root root = JsonSerializer.Deserialize<Root>(response);
            return Ok(root);
        }

        [HttpGet]
        [Route("GetFirstNearbySiteBySearchTerm")]
        public async Task<ActionResult> GetFirstNearbySiteBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            Root root = JsonSerializer.Deserialize<Root>(response);
            if(root.NearbySites != null)
                return Ok(root.NearbySites[0]);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetRecommendedAddressBySearchTerm")]
        public async Task<ActionResult> GetTheRecommendedAddressBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            Root root = JsonSerializer.Deserialize<Root>(response);
            if (root.NearbySites != null && root.NearbySites.Count >0 && root.NearbySites[0].Site != null)
                return Ok("Recommended address: "+root.NearbySites[0].Site.AddressLine1);
            else return NotFound("Nearby sites not found.");
        }


        [HttpGet]
        [Route("GetNearbySitesByLongitudeAndLatitude")]
        public async Task<ActionResult> GetNearbySitesByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, offset, limit, includeAllSites, companyCode);
            List<RootLL> root = JsonSerializer.Deserialize<List<RootLL>>(response); 
            return Ok(root);
        }

        [HttpGet]
        [Route("GetFirstNearbySiteByLongitudeAndLatitude")]
        public async Task<ActionResult> GetFirstNearbySiteByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, offset, limit, includeAllSites, companyCode);
            List<RootLL> root = JsonSerializer.Deserialize<List<RootLL>>(response);
            if (root.Count > 0)
                return Ok(root[0].Site);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetRecommendedAddressByLongitudeAndLatitude")]
        public async Task<ActionResult> GetRecommendedAddressByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, offset, limit, includeAllSites, companyCode);
            List<RootLL> root = JsonSerializer.Deserialize<List<RootLL>>(response);
            if (root.Count > 0)
                return Ok("Recommended address: "+root[0].Site.AddressLine1);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetMenus")]
        public async Task<ActionResult> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup)
        {
            var response = await _client.GetMenus(siteId, promiseTime, includeInvisible, orderMode);
            RootMenus root = JsonSerializer.Deserialize<RootMenus>(response);
            return Ok(root);
        }

        [HttpGet]
        [Route("GetFirstMenuName")]
        public async Task<ActionResult> GetFirstMenuName(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup)
        {
            var response = await _client.GetMenus(siteId, promiseTime, includeInvisible, orderMode);
            RootMenus root = JsonSerializer.Deserialize<RootMenus>(response);
            if (root.Menus != null && root.Menus.Count > 0)
                return Ok(root.Menus[0].Name);
            else return NotFound("Menus not found.");
        }

        [HttpGet]
        [Route("GetTime")]
        public async Task<ActionResult> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            var response = await _client.GetTime(siteId, orderMode, noCache);
            return Ok(response);
        }

        private Order CreateOrder()
        {
            OrderCustomer orderCustomer = new OrderCustomer();
            orderCustomer.EMail = "urosmitrovi@gmail.com";
            orderCustomer.FirstName = "Uros";
            orderCustomer.LastName = "Mitrovic";
            orderCustomer.id = "2";
            Order order = new Order();
            order.SiteId = 1;
            order.Customer = orderCustomer;
            order.Channel = "Unknown";
            order.OrderMode = OrderModeType.Pickup;
            order.PaymentMode = PaymentMode.PaymentDeferred;
            order.PromiseDateTime = new DateTime(2023, 8, 31);
            order.LineItems = new List<InOrderLineItem>
            { new InOrderLineItem() { SalesItemId=40067, MenuItemId=30008} };
            order.ComboItems = new List<ComboItem>();
            order.Guests = new List<Guest>();
            return order;
        }

        [HttpPut]
        [Route("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] Order order, int siteId, bool verbose = false)
        {
            var response = await _client.CreateOrder(order,siteId,verbose);

            //RootOrder root = JsonSerializer.Deserialize<RootOrder>(response); //nastavi 

            return Ok(response);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
