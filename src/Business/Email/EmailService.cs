using Core.APIConfig;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Email
{
    public class EmailService : IEmailService
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public EmailService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient("https://api.apilayer.com/email_verification/");
            _apiKey = apiSettings.Value.ApiKey;
        }

        public async Task<string> VerifyEmailAsync(string email)
        {
            var request = new RestRequest($"email?email={email}", Method.Get);
            request.AddHeader("apikey", _apiKey);

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
