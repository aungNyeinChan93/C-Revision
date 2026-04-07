using Dapper;
using DatabaseTwo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Tuto_05_WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DapperBooksController : ControllerBase
{
    private readonly static string _databaseStr = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

    private IDbConnection dapper;

    public DapperBooksController()
    {
        dapper = new SqlConnection(DapperBooksController._databaseStr);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = dapper.Query<Book>("select * from books where DeleteFlag = 0").ToList();
        if (books is null)
        {
            return NotFound();
        }
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetOne([FromRoute] int id)
    {
        string query = @"select * from books where Deleteflag = 0 and BookId = @BookId";
        var book = dapper.Query<Book>(query,new {BookId = id}).FirstOrDefault();
        return book is not null ? Ok(book) : NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAll([FromRoute]int id ,Book book)
    {
        string query = @"UPDATE [dbo].[Books]
                       SET [Title] = @Title
                          ,[Author] = @Author
                          ,[Year] =@Year
                          ,[DeleteFlag] = 0
                     WHERE BookId = @BookId";
        var result = dapper.Execute(query, new { Title = book?.Title,Author = book?.Author ,Year = book?.Year,BookId = id});
        return result >=1 ? Ok("Update Success") : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute]int id)
    {
        string query = @"UPDATE [dbo].[Books]
                       SET [DeleteFlag] = 1
                     WHERE BookId = @BookId";
        var result = dapper.Execute(query, new { BookId = id });
        return result >=1 ? NoContent():BadRequest();
    }
}
