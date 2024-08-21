using Business.NewyorkTimes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewyorkTimes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewyorkTimesController : ControllerBase
    {

        private readonly INewyorkTimesService _newyorkTimesService;

        public NewyorkTimesController(INewyorkTimesService newyorkTimesService)
        {
            _newyorkTimesService = newyorkTimesService;
        }


        /// <summary>
        ///  Bütün Kur birimleri
        /// </summary>
        /// <returns></returns>

        [HttpGet("mostPopular")]
        public async Task<IActionResult> GetMostPopularNewyorkTimes()
        {
            var result = await _newyorkTimesService.GetMostPopularAsync();
            return Ok(result);
        }
    }
}
