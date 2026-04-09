using Domain_02.Interfaces;
using Domain_02.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Tuto_08_MinimalApi.Endpoints
{
    public static class UserEndPoint
    {

        public static void UseUsers(this IEndpointRouteBuilder app)
        {
            string baseUrl = "https://dummyjson.com/";
            var userApi = RestService.For<UserApi>($"{baseUrl}");


            app.MapGet("/api/users", async () =>
            {
                var users = await userApi.GetAllAsync();
                if (users is null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(users);
            }).WithName("Users");

            app.MapGet("/api/users/{id}", async ([FromRoute]int id) =>
            {
                var user =await userApi.GetOneAsync(id);
                if (user is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            }).WithName("User");

            app.MapPost("/api/users", async(User user) =>
            {
                var res = await userApi.CreateAsync(user);
                if (res is null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(res);
            }).WithName("CrateUser");


            app.MapPut("/api/users/{id}", async (User user, [FromRoute]int id) =>
            {
                var res = await userApi.UpdateAsync(id,user);
                if (res is null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(res);
            }).WithName("UpdateUser");

            app.MapDelete("/api/users/{id}", async ([FromRoute] int id) =>
            {
                var res = await userApi.DeleteAsync(id);
                if (res is null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(res);
            }).WithName("DeleteUser");
        }
    }
}
