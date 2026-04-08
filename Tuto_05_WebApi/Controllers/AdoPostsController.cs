using AdoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Tuto_05_WebApi.Dtos;

namespace Tuto_05_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoPostsController : ControllerBase
    {
        private MyAdoService _servie;

        public AdoPostsController()
        {
            _servie = new MyAdoService();
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
                            where DeleteFlag = @DeleteFlag";

            List<Adoparameter> parameters = new List<Adoparameter>()
            {
                new Adoparameter {Name = "@DeleteFlag" , Value = 0}
            };
            var postTable =  _servie.Query(query,parameters);

            List<PostDto> posts = new List<PostDto>();

            if (postTable is null || postTable.Rows.Count <=0)
            {
                return NotFound();
            }

            foreach (DataRow row in postTable.Rows)
            {
                posts.Add(new PostDto
                {
                    Title = row["Title"].ToString()!,
                    Author = row["Author"].ToString()!,
                    Description = row["Description"].ToString()!,
                    PostId = int.Parse(row["PostId"].ToString()!),
                    //Date = DateTime.Parse(row["Date"].ToString()!),
                    //Date = da.Parse(row["Date"].ToString()!),
                    DeleteFlag = bool.Parse(row["DeleteFlag"].ToString()!),
                }
                );
            }

            return posts.Count >=1 ? Ok(posts) : BadRequest();

        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute]int id)
        {
            string query = @"select * from posts where deleteflag = 0 and PostId = @PostId";
            //List<Adoparameter> adoparameters = new List<Adoparameter>()
            //{
            //    new Adoparameter{Name = "@PostId",Value = id},
            //};

            Adoparameter parameter = new Adoparameter { Name = "@PostId", Value = id };
            var posts = _servie.Query(query, parameter);

            return Ok("get post");
        }

        [HttpPost]
        public IActionResult Create(PostDto postDto)
        {
            string query = @"INSERT INTO [dbo].[Posts]
                           ([Title]
                           ,[Description]
                           ,[Author]
                           ,[Date]
                           ,[DeleteFlag])
                     VALUES
                           (@Title
                           ,@Description
                           ,@Author
                           ,@Date
                           ,0)";

            if (postDto is null) return BadRequest();

            var isSuccess = _servie.Execute(query,
                    new Adoparameter { Name = "@Title", Value = postDto.Title! },
                    new Adoparameter { Name = "@Description",Value = postDto.Description! },
                    new Adoparameter { Name = "@Author",Value = postDto.Author! },
                    new Adoparameter { Name = "@Date",Value = DateTime.Today }
                );
            return isSuccess ?Created() : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id,PostDto postDto)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(postDto?.Title))
            {
                condition += " [Title] = @Title ,";
            }
            if (!string.IsNullOrEmpty(postDto?.Description))
            {
                condition += " [Description] = @Description ,";
            }
            if (!string.IsNullOrEmpty(postDto?.Author))
            {
                condition += " [Author] = @Author ,";
            }

            if (postDto is null)
            {
                return BadRequest();
            }

            string query = $@"UPDATE [dbo].[Posts]
                               SET {condition.Substring(0, condition.Length - 1)}
                             WHERE PostId = @PostId
                            ";

            List<Adoparameter> parameters = new List<Adoparameter>();
            if (!string.IsNullOrEmpty(postDto.Title))
            {
                parameters.Add(new Adoparameter { Name = "@Title", Value = postDto.Title! });
            }
            if (!string.IsNullOrEmpty(postDto.Description))
            {
                parameters.Add(new Adoparameter { Name = "@Description", Value = postDto.Description! });
            }
            if (!string.IsNullOrEmpty(postDto.Author))
            {
                parameters.Add(new Adoparameter { Name = "@Author", Value = postDto.Author! });
            }

            parameters.Add(new Adoparameter { Name = "@PostId", Value = id });

            var isSuccess =_servie.Execute(query,parameters);
            return isSuccess? Ok() : BadRequest(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            string query = @"UPDATE [dbo].[Posts]
                           SET [DeleteFlag] = 1
                         WHERE PostId = @PostId";

            var result = _servie.Execute(query, new Adoparameter { Name = "@PostId", Value = id });
            return result ? NoContent() : BadRequest();

        }
    }
}
