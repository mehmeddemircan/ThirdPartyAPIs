﻿using Core.APIConfig;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exchange
{
    public class ExchangeService : IExchangeService
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public ExchangeService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
            _apiKey = apiSettings.Value.ApiKey;
        }

        public async Task<string> GetCurrencySymbolsAsync()
        {
            var request = new RestRequest("symbols", Method.Get);
            request.AddHeader("apikey", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
