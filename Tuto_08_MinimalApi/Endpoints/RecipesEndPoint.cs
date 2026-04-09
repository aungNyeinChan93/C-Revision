using Domain_02.Models;
using Domain_02.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tuto_08_MinimalApi.Endpoints
{
    public static class RecipesEndPoint
    {
        public static void UseRecipes(this IEndpointRouteBuilder app)
        {
            RecipeService recipeService = new RecipeService();

            app.MapGet("/api/recipes", async () =>
            {
                var result = await recipeService.GetAllAsync();
                if (result is null)
                {
                    return Results.NotFound();
                }
                var recipes = JsonConvert.DeserializeObject<RecipesModel>(result);
                return Results.Ok(recipes);
            }).WithName("Recipes");

            app.MapGet("/api/recipes/{id}", async ([FromRoute]int id) =>
            {
                var result = await recipeService.GetOneAsync(id);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var recipe = JsonConvert.DeserializeObject<Recipe>(result);
                return Results.Ok(recipe);
            }).WithName("Recipe");

            app.MapPost("/api/recipes",async (Recipe recipe) =>
            {
                var result = await recipeService.CreateAsync(recipe);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var r = JsonConvert.DeserializeObject<Recipe>(result);
                return Results.Ok(r);
            }).WithName("CrateRecipe");

            app.MapPut("/api/recipes/{id}", async (Recipe recipe, [FromRoute]int id) =>
            {
                var result = await recipeService.UpdateAsync(recipe,id);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var r = JsonConvert.DeserializeObject<Recipe>(result);
                return Results.Ok(r);
            }).WithName("UpdateRecipe");

            app.MapDelete("/api/recipes/{id}", async ([FromRoute] int id) =>
            {
                var result = await recipeService.Delete(id);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var r = JsonConvert.DeserializeObject<Recipe>(result);
                return Results.Ok(r);
            }).WithName("DeleteRecipe");
        }
    }
}
