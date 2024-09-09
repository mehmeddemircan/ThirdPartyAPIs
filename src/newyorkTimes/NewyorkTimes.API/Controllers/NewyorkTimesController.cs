using Business.NewyorkTimes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewyorkTimes.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewyorkTimesController : ControllerBase
    {

        private readonly INewyorkTimesService _newyorkTimesService;

        public NewyorkTimesController(INewyorkTimesService newyorkTimesService)
        {
            _newyorkTimesService = newyorkTimesService;
        }


     

        [HttpGet("mostPopular")]
        public async Task<IActionResult> GetMostPopularNewyorkTimes()
        {
            var result = await _newyorkTimesService.GetMostPopularAsync();
            return Ok(result);
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooksNewyorkTimes()
        {
            var result = await _newyorkTimesService.GetBooksAsync();
            return Ok(result);
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetBooksNewyorkTimesHttpClient()
        {
            var result = await _newyorkTimesService.GetBooksAsyncHttpClient();
            return Ok(result);
        }
    }
}
