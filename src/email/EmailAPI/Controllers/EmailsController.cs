
using Business.Email;
using Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {

        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            var result = await _emailService.VerifyEmailAsync(email);
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return BadRequest(APIBadRequestConstants.GetFailedEmailVerification);
        }
    }
}
