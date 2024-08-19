using Core.APIConfig;
using DTOs.Communication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Communication
{
    public class CommunicationService : ICommunicationService
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public CommunicationService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient("https://api.apilayer.com/number_verification/");
            _apiKey = apiSettings.Value.ApiKey;
        }

        public async Task<Dictionary<string, CountryResponse>> GetNumberCodeOfCountriesAsync()
        {
            var request = new RestRequest("countries", Method.Get);
            request.AddHeader("apikey", _apiKey);

            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var countries = JsonConvert.DeserializeObject<Dictionary<string, CountryResponse>>(response.Content);
                return countries;
            }
            return null;
        }

        public async Task<string> ValidatePhoneNumberAsync(string number)
        {
            var request = new RestRequest($"validate?number={number}", Method.Get);
            request.AddHeader("apikey", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
