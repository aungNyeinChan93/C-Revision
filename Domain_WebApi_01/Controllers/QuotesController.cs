using DatabaseTwo.Models;
using Domain_01.Features;
using Domain_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Domain_WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuoteService _quoteService;

        public QuotesController()
        {
            this._quoteService = new QuoteService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quotes = _quoteService.AllQuotes();
            if (quotes!.IsError || quotes.ResType == EnumResponseType.Error) return NotFound();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute]int id)
        {
            var quote = _quoteService.GetQuote(id);
            return quote is null ? NotFound() : Ok(quote);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]Quote quote)
        {
            var isSuccess = _quoteService.Create(quote);
            return isSuccess ? Ok("Create success") : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id,Quote quote)
        {
            var isSuccess = _quoteService.Update(id, quote);
            return isSuccess ? Ok("Update Success") : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var isSuccess = _quoteService.Delete(id);
            return isSuccess ? NoContent() : BadRequest();
        }
    }
}
