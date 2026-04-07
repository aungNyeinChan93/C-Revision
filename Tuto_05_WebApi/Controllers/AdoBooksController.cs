using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tuto_05_WebApi.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tuto_05_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoBooksController : ControllerBase
    {
        private readonly string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        private SqlConnection _connection;

        public AdoBooksController()
        {
            _connection = new SqlConnection(this._databaseString);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BookDto> books = new List<BookDto>();
            _connection.Open();
            string query = @"select * from books where deleteflag = 0";
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new BookDto() 
                {
                    BookId = int.Parse(reader["BookId"].ToString()!),
                    Title = reader["Title"].ToString()!,
                    Author = reader["Author"].ToString()! ,
                    Year = int.Parse(reader["Year"].ToString()!),
                    DeleteFlag = bool.Parse(reader["DeleteFlag"].ToString()!)
                });
            }
            _connection.Close();
            return Ok(new {books});

        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute]int id)
        {
            _connection.Open();

            List<BookDto> books = new List<BookDto>();
            string query = $@"select * from Books where deleteflag = 0 and BookId = @BookId";
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BookId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new BookDto
                {
                    BookId = int.Parse(reader["BookId"].ToString()!),
                    Title = reader["Title"].ToString()!,
                    Author = reader["Author"].ToString()!,
                    Year = int.Parse(reader["Year"].ToString()!),
                    DeleteFlag = false
                });
            }
            _connection.Close();

            if (books.Count <=0 )
            {
                return NotFound();
            }

            return Ok(new {book = books[0] });
        }

        [HttpPost]
        public IActionResult Create(BookDto bookDto)
        {
            _connection.Open();
            string query = @"INSERT INTO [dbo].[Books]
                           ([Title]
                           ,[Author]
                           ,[Year],
                           [DeleteFlag])
                            VALUES
                               (@Title
                               ,@Author
                               ,@Year,
                                0)";
            SqlCommand cmd = new SqlCommand(query,_connection);
            cmd.Parameters.AddWithValue("@Title",bookDto?.Title);
            cmd.Parameters.AddWithValue("@Author",bookDto?.Author);
            cmd.Parameters.AddWithValue("@Year",bookDto?.Year);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result >= 1 ? Ok("Create Success") : BadRequest();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateOne([FromRoute]int id, BookDto bookDto)
        {
            _connection.Open();

            string condition = "";

            if (!string.IsNullOrEmpty(bookDto.Title))
            {
                condition += " [Title] = @Title,";
            };
            if (!string.IsNullOrEmpty(bookDto.Author))
            {
                condition += " [Author] = @Author,";
            };
            if (bookDto.Year >=1)
            {
                condition += " [Year] = @Year,";
            };

            string query = @$"UPDATE [dbo].[Books]
                       SET {condition.Substring(0,condition.Length-1)} 
                     WHERE BookId = @BookId";

            if (bookDto is null && condition.Length <=0) return BadRequest();

            SqlCommand cmd = new SqlCommand(query,_connection);

            cmd.Parameters.AddWithValue("@Title",bookDto?.Title);
            cmd.Parameters.AddWithValue("@Author",bookDto?.Author);
            cmd.Parameters.AddWithValue("@Year",bookDto?.Year);
            cmd.Parameters.AddWithValue("@BookId",id);

            int result = cmd.ExecuteNonQuery();

            _connection.Close();

            return result >=1 ? Ok("Update Success"):BadRequest();        
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            string query = @"UPDATE [dbo].[Books]
                       SET [DeleteFlag] = 1
                     WHERE BookId = @BookId and DeleteFlag = 0";

            _connection.Open();

            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@BookId",id);
            var result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result >= 1 ? NoContent() : BadRequest();    

        }
    }

}
