using Domain_01.Features;
using Microsoft.AspNetCore.Http;
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
            return books is not null || books.Count >= 1 ? Ok(books) : NotFound();
        }
    }
}
