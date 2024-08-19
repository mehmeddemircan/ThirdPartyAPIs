using Core.APIConfig;
using DTOs.Translation;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Translation
{
    public class TranslationService : ITranslationService
    {

        private readonly RestClient _client;
        private readonly string _apiKey;

        public TranslationService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
            _apiKey = apiSettings.Value.ApiKey;
        }

        public async Task<string> GetSupportedLanguagesAsync()
        {
            var request = new RestRequest("languages", Method.Get);
            request.AddHeader("apikey", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> IdentifyLanguage(string text)
        {
            var request = new RestRequest("identify", Method.Post);
            request.AddHeader("apikey", _apiKey);

            request.AddParameter("text/plain", text, ParameterType.RequestBody);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }

        public async Task<string> TranslateTextAsync(TranslationRequest requestDto)
        {
            var request = new RestRequest($"translate?target=${requestDto.Target}&source=${requestDto.Source}", Method.Post);
            request.AddHeader("apikey", _apiKey);
            request.AddHeader("Content-Type", "text/plain");

            request.AddParameter("text/plain", requestDto.Text, ParameterType.RequestBody);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
