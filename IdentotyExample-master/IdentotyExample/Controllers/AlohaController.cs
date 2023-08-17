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
using System.Diagnostics;

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
            try
            {
                var response = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
                return Ok(response);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet]
        [Route("GetNearbySitesByLongitudeAndLatitude")]
        public async Task<ActionResult> GetNearbySitesByLongitudeAndLatitude(double latitude, double longitude, OrderModeType orderMode = OrderModeType.Pickup, int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            try
            {
                var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, companyCode, offset, limit, includeAllSites);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetMenus")]
        public async Task<ActionResult> GetMenus(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, OrderModeType orderMode = OrderModeType.Pickup)
        {
            try
            {
                List<MenuItemOverride> menuItemOverrideList = await _context.MenuItemOverrides.ToListAsync();
                var response = await _client.GetMenus(menuItemOverrideList, siteId, promiseTime, orderMode, includeInvisible);
                OutRootMenusDTO modifiedMenus = MenuHelper.GetModifiedMenu(siteId, menuItemOverrideList, response);
                return Ok(modifiedMenus);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTime")]
        public async Task<ActionResult> GetTime(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            try
            {
                var response = await _client.GetTime(siteId, orderMode, noCache);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
            try
            {
                var response = await _client.CreateOrder(inOrderDTO, siteId, verbose);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
