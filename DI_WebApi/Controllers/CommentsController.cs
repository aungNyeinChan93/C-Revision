using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Models;
using Services.Services;

namespace DI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var str = await _commentService.GetAllAsync();
            if (str is null)
            {
                return NotFound();
            };

            var commentModel = JsonConvert.DeserializeObject<CommentsModel>(str);
            if (commentModel is null)
            {
                return NotFound();
            }
            return Ok(commentModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute]int id)
        {
            var str = await _commentService.GetOneAsync(id);
            if (str is null)
            {
                return NotFound();
            };

            var commentModel = JsonConvert.DeserializeObject<Comment>(str);
            if (commentModel is null)
            {
                return NotFound();
            }
            return Ok(commentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Comment comment)
        {
            var str = await _commentService.CreateAsync(comment);
            if (str is null)
            {
                return NotFound();
            }
            ;

            var commentModel = JsonConvert.DeserializeObject<Comment>(str);
            if (commentModel is null)
            {
                return NotFound();
            }
            return Ok(commentModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var str = await _commentService.DeleteAsync(id);
            if (str is null)
            {
                return NotFound();
            }
            ;

            var commentModel = JsonConvert.DeserializeObject<Comment>(str);
            if (commentModel is null)
            {
                return NotFound();
            }
            return Ok(commentModel);
        }
    }
}
