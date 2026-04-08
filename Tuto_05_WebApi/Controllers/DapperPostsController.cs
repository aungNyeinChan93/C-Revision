using DapperService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuto_05_WebApi.Dtos;

namespace Tuto_05_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperPostsController : ControllerBase
    {
        private MyDapperService _service;

        public DapperPostsController()
        {
            _service = new MyDapperService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string query = @"SELECT [PostId]
                          ,[Title]
                          ,[Description]
                          ,[Author]
                          ,[Date]
                          ,[DeleteFlag]
                            FROM [dbo].[Posts]
                            where DeleteFlag = 0";
            var posts = _service.Query<PostDto>(query);
            return posts is null ? NotFound() : Ok(posts);
        }
    }
}
