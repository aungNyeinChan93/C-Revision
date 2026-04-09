using Microsoft.AspNetCore.Mvc;
using Tuto_09_MinimalApi.Inteerface;
using Tuto_09_MinimalApi.Models;

namespace Tuto_09_MinimalApi.EndPoints
{
    public static class EFCoreBookEndPoint
    {
        public static void UseEfCoreBook(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/efbooks", async ([FromServices] IBookApi bookApi) =>
            {
                var books = await bookApi.GetAllAsync();
                return Results.Ok(books);
            });

            app.MapGet("/api/efbooks/{id}", async ([FromServices] IBookApi bookApi, int id) =>
            {
                var book = await bookApi.GetOneAsync(id);
                return Results.Ok(book);
            });

            app.MapDelete("/api/efbooks/{id}", async ([FromServices] IBookApi bookApi, int id) =>
            {
                var book = await bookApi.DeleteAsync(id);
                return Results.Ok(book);
            });

            app.MapPost("/api/efbooks", async ([FromServices] IBookApi bookApi,Book book) =>
            {
                var b = await bookApi.CreateAsync(book);
                return Results.Ok(b);

            });

            app.MapPut("/api/efbooks/{id}", async ([FromServices] IBookApi bookApi, Book book,int id) =>
            {
                var b = await bookApi.UpdateAsync(book,id);
                return Results.Ok(b);

            });



        }
    }
}
