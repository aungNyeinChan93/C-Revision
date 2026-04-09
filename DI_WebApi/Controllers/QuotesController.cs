using DatabaseTwo.Models;
using Domain_01.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteService _service;

        public QuotesController(QuoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var quotes = _service.AllQuotes();
            if (quotes == null) return BadRequest();
            if (quotes.IsError)
            {
                return BadRequest();
            }
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync([FromRoute]int id)
        {
            var quote = _service.GetQuote(id);
            if (quote == null) return BadRequest();
            if (quote.IsError)
            {
                return BadRequest();
            }
            return Ok(quote);

        }
    }
}
