using DatabaseTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tuto_06_MinimalApi.EndPoints
{
    public static class BookEndPoint
    {

        // extension method 
        public static void UseBook(this IEndpointRouteBuilder app )
        {

            app.MapGet("/api/books", () =>
            {
                AppDbContext _db = new AppDbContext();
                var books = _db.Books.AsNoTracking().Where(b => b.DeleteFlag == false).ToList();
                return books.Count >= 1 ? Results.Ok(books) : Results.NotFound();
            }).WithName("GetAllBooks");

            app.MapGet("/api/books/{id}", ([FromRoute] int id) =>
            {
                AppDbContext _db = new AppDbContext();
                var book = _db.Books.AsNoTracking().Where(b => b.DeleteFlag == false && b.BookId == id).FirstOrDefault();
                return book is not null ? Results.Ok(book) : Results.NotFound();
            }).WithName("GetBook");

            app.MapPost("/api/books", (Book book) =>
            {
                AppDbContext _db = new AppDbContext();
                _db.Add(book);
                var result = _db.SaveChanges();
                return result >= 1 ? Results.Ok("Create Success") : Results.BadRequest();
            }).WithName("CreateBook");

            app.MapPut("/api/books/{id}", (Book book, [FromRoute] int id) =>
            {
                AppDbContext _db = new AppDbContext();
                var b = _db.Books.AsNoTracking().Where(b => b.DeleteFlag == false && b.BookId == id).FirstOrDefault();
                if (b is null)
                {
                    return Results.BadRequest();
                }
                b.Title = book.Title;
                b.Author = book.Author;
                b.Year = book.Year;

                _db.Entry(b).State = EntityState.Modified;
                var res = _db.SaveChanges();
                return res >= 1 ? Results.Created() : Results.BadRequest();

            }).WithName("UpdateBook");

            app.MapDelete("/api/books/{id}", ([FromRoute] int id) =>
            {
                AppDbContext _db = new AppDbContext();
                var b = _db.Books.AsNoTracking().Where(b => b.DeleteFlag == false && b.BookId == id).FirstOrDefault();
                if (b is null) return Results.BadRequest();
                b.DeleteFlag = true;
                _db.Entry(b).State = EntityState.Modified;
                var result = _db.SaveChanges();
                return result >= 1 ? Results.NoContent() : Results.BadRequest();
            }).WithName("DeleteBook");
        }
    }
}
