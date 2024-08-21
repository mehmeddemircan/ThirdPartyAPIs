using Core.APIConfig;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.NewyorkTimes
{
    public class NewyorkTimesService : INewyorkTimesService
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public NewyorkTimesService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
            _apiKey = apiSettings.Value.ApiKey;
        }

        public async Task<string> GetMostPopularAsync()
        {
            var request = new RestRequest("emailed/7.json", Method.Get);
            request.AddQueryParameter("api-key", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
