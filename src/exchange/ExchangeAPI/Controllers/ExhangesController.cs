using Business.Exchange;
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
    }
}
