using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
            string city = root.NearbySites[0].Site.City;
            return Ok(city);
        }





        public IActionResult Index()
        {
            return View();
        }
    }
}
