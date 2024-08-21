using Core.APIConfig;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.weatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly RestClient _client;


        public WeatherForecastService(IOptions<ApiSettings> apiSettings)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
           
        }

        public async Task<string> GetWeatherTypesAsync()
        {
            var request = new RestRequest("weather_conditions.json", Method.Get);
           

            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
