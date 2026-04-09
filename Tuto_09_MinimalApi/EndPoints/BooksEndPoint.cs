using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Tuto_09_MinimalApi.Models;

namespace Tuto_09_MinimalApi.EndPoints
{
    public static class BooksEndPoint
    {
        public static void UseBooks(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/books", async ([FromServices] RestClient restClient) =>
            {
                var request = new RestRequest("api/dapperBooks", Method.Get);
                var response = await restClient.GetAsync(request);
                var str = response.Content!;
                var result = JsonConvert.DeserializeObject<List<Book>>(str);
                return Results.Ok(result);
            });

            app.MapGet("/api/books/{id}", async ([FromServices] RestClient restClient,int id) =>
            {
                var request = new RestRequest($"api/dapperBooks/{id}", Method.Get);
                var response = await restClient.GetAsync(request);
                var str = response.Content!;
                var result = JsonConvert.DeserializeObject<Book>(str);
                return Results.Ok(result);
            });

            app.MapPost("/api/books", async ([FromServices] RestClient restClient ,Book book) =>
            {
                var request = new RestRequest($"api/dapperBooks", Method.Post);
                request.AddJsonBody<Book>(book);
                var response = await restClient.ExecuteAsync(request);
                return response.Content!;
            });

            app.MapPut("/api/books/{id}", async ([FromServices] RestClient restClient, Book book,int id) =>
            {
                var request = new RestRequest($"api/dapperBooks/{id}", Method.Put);
                request.AddJsonBody<Book>(book);
                var response = await restClient.ExecuteAsync(request);
                return response.Content!;
            });

            app.MapDelete("/api/books/{id}", async ([FromServices] RestClient restClient, int id) =>
            {
                var request = new RestRequest($"api/dapperBooks/{id}", Method.Delete);
                var response = await restClient.ExecuteAsync(request);
                return response.Content!;
            });
        }
    }
}
