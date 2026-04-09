using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Tuto_09_MinimalApi.Models;

namespace Tuto_09_MinimalApi.EndPoints
{
    public static class PostsEndPoint
    {
        public static void UsePost(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/posts", async([FromServices] HttpClient httpClient) =>
            {
                var postsModel = new PostsModel();
                var response= await httpClient.GetAsync("/posts");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    postsModel = JsonConvert.DeserializeObject<PostsModel>(str);
                }
                return Results.Ok(postsModel);
            }).WithName("Posts");

            app.MapGet("/api/posts/{id}", async ([FromServices] HttpClient httpClient, [FromRoute] int id) =>
            {
                var response = await httpClient.GetAsync($"/posts/{id}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest();
                }
                var str = await response.Content.ReadAsStringAsync();
                var postsModel = JsonConvert.DeserializeObject<Post>(str);
                return Results.Ok(postsModel);
            }).WithName("Post");

            app.MapPost("/api/posts", async ([FromServices] HttpClient httpClient, Post post) =>
            {
                var jsonStr = JsonConvert.SerializeObject(post);
                var strContnet = new StringContent(jsonStr,Encoding.UTF8,"application/json");
                var response = await httpClient.PostAsync($"/posts/add",strContnet);
               
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest();
                }
                var str = await response.Content.ReadAsStringAsync();
                var postsModel = JsonConvert.DeserializeObject<Post>(str);
                return Results.Ok(postsModel);
            }).WithName("CreatePost");

            app.MapPut("/api/posts/{id}", async ([FromServices] HttpClient httpClient, Post post,int id) =>
            {
                var jsonStr = JsonConvert.SerializeObject(post);
                var strContnet = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"/posts/{id}", strContnet);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest();
                }
                var str = await response.Content.ReadAsStringAsync();
                var postsModel = JsonConvert.DeserializeObject<Post>(str);
                return Results.Ok(postsModel);
            }).WithName("UpdatePost");

            app.MapDelete("/api/posts/{id}", async ([FromServices] HttpClient httpClient, int id) =>
            {
                var response = await httpClient.DeleteAsync($"/posts/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return Results.NotFound();
                }
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest();
                }
                var str = await response.Content.ReadAsStringAsync();
                var postsModel = JsonConvert.DeserializeObject<Post>(str);
                return Results.Ok(postsModel);
            }).WithName("DeletePost");

        }
    }
}
