﻿using Core.APIConfig;
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

        public async Task<string> GetMostPopularAsync()
        {
            var request = new RestRequest("mostpopular/v2/emailed/7.json", Method.Get);
            request.AddQueryParameter("api-key", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
