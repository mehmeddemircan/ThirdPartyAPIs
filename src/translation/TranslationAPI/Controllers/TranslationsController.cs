using Business.Translation;
using Core.Constants;
using DTOs.Translation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TranslationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationsController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("languages")]
        public async Task<IActionResult> GetSupportedLanguages()
        {
            var result = await _translationService.GetSupportedLanguagesAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(APIBadRequestConstants.GetFailedLanguages);
        }
        [HttpPost("identify")]
        public async Task<IActionResult> IdentifyLanguage( string text)
        {
            var result = await _translationService.IdentifyLanguage(text);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Language could not detected");
        }

        [HttpPost("translate")]
        public async Task<IActionResult> TranslateText( TranslationRequest request)
        {
            var result = await _translationService.TranslateTextAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Translation failed.");
        }
    }
}
