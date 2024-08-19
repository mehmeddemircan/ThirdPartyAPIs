using Business.Communication;
using Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryNumbersController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;

        public CountryNumbersController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetNumberCodesOfCountries()
        {
            var result = await _communicationService.GetNumberCodeOfCountriesAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(APIBadRequestConstants.GetFailedCountriesNumber);
        }

    }
}
