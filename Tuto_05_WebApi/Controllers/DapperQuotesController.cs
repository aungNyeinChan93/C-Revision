using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Tuto_05_WebApi.Dtos;

namespace Tuto_05_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperQuotesController : ControllerBase
    {
        private readonly string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        private IDbConnection _dapper;

        public DapperQuotesController()
        {
            _dapper = new SqlConnection(this._databaseString);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<QuoteDto>? quotes = _dapper.Query<QuoteDto>("select * from quotes").ToList();
            return quotes.Count >= 1 ? Ok(quotes) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute]int id)
        {
            string query = @"SELECT [QuoteId]
                          ,[Quote]
                          ,[Author]
                      FROM [dbo].[Quotes] 
                        where QuoteId = @QuoteId";
            QuoteDto? quote = _dapper.Query<QuoteDto>(query,new {QuoteId = id}).FirstOrDefault();
            return quote is null ?  NotFound() : Ok(quote);
        }

        [HttpPost]
        public IActionResult Create(QuoteDto quoteDto)
        {
            string query = @"INSERT INTO [dbo].[Quotes]
                               ([Quote]
                               ,[Author])
                            VALUES
                               (@Quote
                               ,@Author)";
            int result = _dapper.Execute(query, quoteDto);
            return result >= 1 ? Created() : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOne([FromRoute] int id, QuoteDto quoteDto)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(quoteDto?.Quote))
            {
                condition += " [Quote] = @Quote ,";
            }
            if (!string.IsNullOrEmpty(quoteDto?.Author))
            {
                condition += " [Author] = @Author ,";
            }
            if (quoteDto is null)
            {
                return BadRequest();
            }

            string query = @$"UPDATE [dbo].[Quotes]
                           SET {condition.Substring(0, condition.Length - 1)}
                         WHERE QuoteId = @QuoteId";

            var result = _dapper.Execute(query, new { QuoteId = id, Quote = quoteDto.Quote, Author = quoteDto.Author });
            return result >= 1 ? Ok("Update Success") : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            string query = @"
                        DELETE FROM [dbo].[Quotes]
                              WHERE QuoteId = @QuoteId";

            var res = _dapper.Execute(query, new { QuoteId = id });
            return res >=1 ? NoContent() : BadRequest();
        }

    }
}
