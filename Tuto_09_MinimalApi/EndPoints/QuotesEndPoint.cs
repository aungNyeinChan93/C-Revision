using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Tuto_09_MinimalApi.Models;

namespace Tuto_09_MinimalApi.EndPoints
{
    public static class QuotesEndPoint
    {

        public static void UseQuotes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/quotes", async ([FromKeyedServices] RestClient restClient) =>
            {
                var request = new RestRequest("/quotes", Method.Get);
                var response = await restClient.ExecuteAsync(request);
                var quotesModel = JsonConvert.DeserializeObject<QuotesModel>(response.Content!);
                return quotesModel;
            }).WithName("Quotes");

            app.MapGet("/api/quotes/{id}", async ([FromKeyedServices] RestClient restClient,int id) =>
            {
                var request = new RestRequest($"/quotes/{id}", Method.Get);
                var response = await restClient.ExecuteAsync(request);
                var quotesModel = JsonConvert.DeserializeObject<Quote>(response.Content!);
                return quotesModel;
            }).WithName("Quote");

            app.MapPost("/api/quotes", async ([FromServices] RestClient restClient ,Quote quote) =>
            {
                var request = new RestRequest("/quotes/add",Method.Post);
                request.AddJsonBody<Quote>(quote);
                var response = await restClient.ExecuteAsync(request);
                var q = JsonConvert.DeserializeObject<Quote>(response.Content!);
                return response.Content!;
            });

            app.MapDelete("/api/quotes/{id}", async ([FromKeyedServices] RestClient restClient, int id) =>
            {
                var request = new RestRequest($"/quotes/{id}", Method.Delete);
                var response = await restClient.DeleteAsync(request);
                var quotesModel = JsonConvert.DeserializeObject<Quote>(response.Content!);
                return quotesModel;
            }).WithName("DeleteQuote");
        }
    }
}
