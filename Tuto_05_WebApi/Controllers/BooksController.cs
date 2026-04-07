using DatabaseTwo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tuto_05_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BooksController()
        {
            this._db = new AppDbContext(); 
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books =_db.Books
                .AsNoTracking()
                .Where(b => b.DeleteFlag == false)
                .ToList();
            return Ok(new {data = books,message = "Get all Books "});
        }

        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute]int id)
        {
            var book = _db.Books.AsNoTracking().FirstOrDefault(b => b.DeleteFlag != true && b.BookId == id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _db.Books.Add(book);
            int result = _db.SaveChanges();
            return result >=1 ? Created() : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute]int id ,Book book)
        {
            var b = _db.Books.AsNoTracking().FirstOrDefault(b => b.DeleteFlag != true && b.BookId == id);
            if (b is null)
            {
                return NotFound();
            }
            b.Title = book.Title;
            b.Author = book.Author;
            b.Year = book.Year;

            _db.Entry(b).State = EntityState.Modified;
            int result = _db.SaveChanges();
            
            return result >=1 ? Ok("Update success"): BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = _db.Books.AsNoTracking().FirstOrDefault(b => b.DeleteFlag == false && b.BookId == id);
            if (book is null) return NotFound();
            book.DeleteFlag = true;
            _db.Entry(book).State = EntityState.Modified;
            int result = _db.SaveChanges();
            return result >= 1 ? NoContent() : BadRequest();
        }

        [HttpPatch("{id}")] 
        public IActionResult UpdateOne([FromRoute]int id,Book? book)
        {

            var b = _db.Books.AsNoTracking().FirstOrDefault(b => b.DeleteFlag != true && b.BookId == id);

            if (b is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(book.Title))
            {
                b.Title = book.Title;
            }
            if (!string.IsNullOrEmpty(book.Author))
            {
                b.Author = book.Author;
            }
            if (book.Year >=1)
            {
                b.Year = book.Year;
            }
           
            _db.Entry(b).State = EntityState.Modified;
            int result = _db.SaveChanges();

            return result >= 1 ? Ok("Update success") : BadRequest();
        }
    }
}
