using Business.FakeJSON;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeJSONAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FakeJSONsController : ControllerBase
    {
        private readonly IFakeJSONService _fakeJSONService;

        public FakeJSONsController(IFakeJSONService fakeJSONService)
        {
            _fakeJSONService = fakeJSONService;
        }

        [HttpGet]

        public async Task<IActionResult> GetPosts()
        {
          var result =   await _fakeJSONService.GetPosts();
            return Ok(result);
        }


        [HttpGet("{postId}")]

        public async Task<IActionResult> GetPostsById(int postId)
        {
            var result = await _fakeJSONService.GetPostsById(postId);
            return Ok(result);
        }
        [HttpGet("{postId}")]

        public async Task<IActionResult> GetCommentsOfPostById(int postId)
        {
            var result = await _fakeJSONService.GetCommentsOfPost(postId);
            return Ok(result);
        }


        [HttpGet]

        public async Task<IActionResult> GetComments()
        {
            var result = await _fakeJSONService.GetComments();
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetAlbums()
        {
            var result = await _fakeJSONService.GetAlbums();
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetPhotos()
        {
            var result = await _fakeJSONService.GetPhotos();
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetTodos()
        {
            var result = await _fakeJSONService.GetTodos();
            return Ok(result);
        }
        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {
            var result = await _fakeJSONService.GetUsers();
            return Ok(result);
        }
    }
}
