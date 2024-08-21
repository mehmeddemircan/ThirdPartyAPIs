using Business.weatherForecast;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastsController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("weatherTypes")]
        public async Task<IActionResult> GetWeatherTypes()
        {
            var result = await _weatherForecastService.GetWeatherTypesAsync();
            return Ok(result);
        }
    }
}
