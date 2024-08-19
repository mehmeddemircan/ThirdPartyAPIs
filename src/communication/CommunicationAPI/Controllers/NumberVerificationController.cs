using Business.Communication;
using Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberVerificationController : ControllerBase
    {

        private readonly ICommunicationService _communicationService;

        public NumberVerificationController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidatePhoneNumber(string number)
        {
            var result = await _communicationService.ValidatePhoneNumberAsync(number);
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return BadRequest(APIBadRequestConstants.GetFailedVerifyNumber);
        }
    }
}
