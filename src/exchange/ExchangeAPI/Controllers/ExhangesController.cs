using Business.Exchange;
using DTOs.Currency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhangesController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExhangesController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }
        
        
        /// <summary>
        ///  Bütün Kur birimleri
        /// </summary>
        /// <returns></returns>

        [HttpGet("symbols")]
        public async Task<IActionResult> GetCurrencySymbols()
        {
            var result = await _exchangeService.GetCurrencySymbolsAsync();
            return Ok(result);
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] CurrencyConversionRequest currencyConversionRequest)
        {
            var result = await _exchangeService.ConvertCurrencyAsync(currencyConversionRequest);
            return Ok(result);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestRates([FromQuery] LatestRatesRequest latestRatesRequest)
        {
            var result = await _exchangeService.GetLatestRates(latestRatesRequest);
            return Ok(result);
        }
    }
}
