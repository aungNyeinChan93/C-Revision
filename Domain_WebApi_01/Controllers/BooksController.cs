using DatabaseTwo.Models;
using Domain_01.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Domain_WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.Read();
            return books is not null || books!.Response!.IsSuccess ? Ok(books) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute]int id)
        {
            var book = _bookService.ReadOne(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            bool isSuccess = _bookService.Create(book);
            return isSuccess ? Created() : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id,Book book)
        {
            var res = _bookService.Update(id, book);
            return res ? Ok("Update Success") : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var res = _bookService.Delete(id);
            return res ? NoContent() : BadRequest();
        }

    }
}
