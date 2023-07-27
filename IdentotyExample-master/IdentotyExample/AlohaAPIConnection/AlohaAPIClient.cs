using System.Net.Http.Headers;
using System.Text;

public class AlohaAPIClient
    {
        private const string BaseUrl = "https://api.alohaorderonline.com";
        private readonly HttpClient _httpClient;

        public AlohaAPIClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

    public void AddDefaultRequestHeaders(Action<HttpRequestHeaders> action)
    {
        action?.Invoke(_httpClient.DefaultRequestHeaders);
    }



    public async Task<string> PostAsync(string endpoint, string jsonContent)
    {
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetAsync(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }




}

