using Domain_01.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Domain_WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private PostService _postService;

        public PostsController()
        {
            this._postService = new PostService();
        }

        [HttpGet]
        public async Task<IActionResult>? GetAll()
        {
            var result = await _postService.GetAllAsync();
             
            if (result.IsError) return NotFound();

            return Ok(result);
        }
    }
}
