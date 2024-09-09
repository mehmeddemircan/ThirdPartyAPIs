using Core.APIConfig;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.NewyorkTimes
{
    public class NewyorkTimesService : INewyorkTimesService
    {
        private readonly RestClient _client;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NewyorkTimesService(IOptions<ApiSettings> apiSettings, IHttpClientFactory httpClientFactory)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
            _apiKey = apiSettings.Value.ApiKey;
            _httpClient = httpClientFactory.CreateClient("NewyorkTimesClient");
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }
        /// <summary>
        /// Serialize Deserialize nedir ? 
        /// 
        /// Serialize :  C# nesnesini JSON formatına dönüştürmek, serileştirme
        ///  Deserialize :  JSON formatındaki bir string'i verdiğimiz nesne işlemine dönüştürür
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetBooksAsync()
        {
            var request = new RestRequest("books/v3/lists/current/hardcover-fiction.json", Method.Get);
            request.AddQueryParameter("api-key", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> GetBooksAsyncHttpClient()
        {
            var url = $"books/v3/lists/current/hardcover-fiction.json?api-key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();  
            return responseData;
        }

        public async Task<string> GetMostPopularAsync()
        {
            var request = new RestRequest("mostpopular/v2/emailed/7.json", Method.Get);
            request.AddQueryParameter("api-key", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
