using AlohaAPIExample.Helpers;
using AlohaAPIExample.Models;
using AlohaAPIExample.Models.Dto;
using AutoMapper;
using IdentotyExample.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Controllers
{
    public class AlohaController : Controller
    {
        private readonly AlohaAPIClient _client;
        private readonly DataContext _context;

        public AlohaController(AlohaAPIClient client, DataContext context)
        {
            _client = client;
            _context = context;
        }

        [HttpGet]
        [Route("GetNearbySitesBySearchTerm")]
        public async Task<ActionResult> GetNearbySitesBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetFirstNearbySiteBySearchTerm")]
        public async Task<ActionResult> GetFirstNearbySiteBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            if(response.NearbySites != null)
                return Ok(response.NearbySites[0]);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetRecommendedAddressBySearchTerm")]
        public async Task<ActionResult> GetTheRecommendedAddressBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            if (response.NearbySites != null && response.NearbySites.Count >0 && response.NearbySites[0].Site != null)
                return Ok("Recommended address: "+response.NearbySites[0].Site.AddressLine1);
            else return NotFound("Nearby sites not found.");
        }


        [HttpGet]
        [Route("GetNearbySitesByLongitudeAndLatitude")]
        public async Task<ActionResult> GetNearbySitesByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, companyCode, offset, limit, includeAllSites);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetFirstNearbySiteByLongitudeAndLatitude")]
        public async Task<ActionResult> GetFirstNearbySiteByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, companyCode, offset, limit, includeAllSites);
            if (response.Count > 0)
                return Ok(response[0].Site);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetRecommendedAddressByLongitudeAndLatitude")]
        public async Task<ActionResult> GetRecommendedAddressByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, companyCode, offset, limit, includeAllSites);
            if (response.Count > 0)
                return Ok("Recommended address: "+response[0].Site.AddressLine1);
            else return NotFound("Nearby sites not found.");
        }

        [HttpGet]
        [Route("GetMenus")]
        public async Task<ActionResult> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup)
        {
            List<MenuItemOverride> menuItemOverrideList = await _context.MenuItemOverrides.ToListAsync();
            var response = await _client.GetMenus(menuItemOverrideList, siteId, promiseTime, orderMode, includeInvisible);
            OutRootMenusDTO modifiedMenus = MenuHelper.GetModifiedMenu(siteId, menuItemOverrideList, response);
            return Ok(modifiedMenus);
        }

        [HttpGet]
        [Route("GetTime")]
        public async Task<ActionResult> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            var response = await _client.GetTime(siteId, orderMode, noCache);
            return Ok(response);
        }

        //private Order CreateOrder()
        //{
        //    OrderCustomer orderCustomer = new OrderCustomer();
        //    orderCustomer.EMail = "urosmitrovi@gmail.com";
        //    orderCustomer.FirstName = "Uros";
        //    orderCustomer.LastName = "Mitrovic";
        //    orderCustomer.id = "2";
        //    Order order = new Order();
        //    order.SiteId = 1;
        //    order.Customer = orderCustomer;
        //    order.Channel = "Unknown";
        //    order.OrderMode = OrderModeType.Pickup;
        //    order.PaymentMode = PaymentMode.PaymentDeferred;
        //    order.PromiseDateTime = new DateTime(2023, 8, 31);
        //    order.LineItems = new List<InOrderLineItem>
        //    { new InOrderLineItem() { SalesItemId=40067, MenuItemId=30008} };
        //    order.ComboItems = new List<ComboItem>();
        //    order.Guests = new List<Guest>();
        //    return order;
        //}

        [HttpPut]
        [Route("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] InOrderDTO inOrderDTO, int siteId, bool verbose = false)
        {
            var response = await _client.CreateOrder(inOrderDTO,siteId,verbose);
            return Ok(response);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
