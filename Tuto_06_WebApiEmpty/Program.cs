using DatabaseThree.Models;
using DatabaseTwo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/databaseTwo", () =>
{
    DatabaseTwo.Models.AppDbContext db = new DatabaseTwo.Models.AppDbContext();
    var books = db.Books.AsNoTracking().Where(b => b.DeleteFlag == false).ToList();
    return books;
});

app.MapGet("/databaseThree", () =>
{
    DatabaseThree.Models.AppDbContext _db = new DatabaseThree.Models.AppDbContext();
    var blogs = _db.Blogs.AsNoTracking().ToList();
    return blogs;
});

app.Run();


