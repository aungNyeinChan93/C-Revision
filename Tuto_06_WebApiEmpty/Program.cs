using DatabaseTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tuto_06_MinimalApi.EndPoints;
using Tuto_06_MinimalApi.Tests;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//app.MapGet("/databaseTwo", () =>
//{
//    DatabaseTwo.Models.AppDbContext db = new DatabaseTwo.Models.AppDbContext();
//    var books = db.Books.AsNoTracking().Where(b => b.DeleteFlag == false).ToList();
//    return books;
//});

//app.MapGet("/databaseThree", () =>
//{
//    DatabaseThree.Models.AppDbContext _db = new DatabaseThree.Models.AppDbContext();
//    var blogs = _db.Blogs.AsNoTracking().ToList();
//    return blogs;
//});

//BookEndPoint.UseBook(app);
app.UseBook();



app.MapGet("/api/test1", () =>
{
    Book book = new Book();
    return book.Test();

}).WithName("TestOne");


app.Run();


