using Domain_02.Models;
using Domain_02.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tuto_08_MinimalApi.Entities;

namespace Tuto_08_MinimalApi.Endpoints
{
    public static class TodoEndpoint
    {
        
        public static void UseTodo(this IEndpointRouteBuilder app)
        {
            TodoService todoService = new TodoService();

            app.MapGet("/api/todos",async () =>
            {
                var result = await todoService.GetAllAsync()!;
                if (result is null) return Results.NotFound();

                var todos = JsonConvert.DeserializeObject<Todos>(result);
                return Results.Ok(todos);

            }).WithName("Todos");

            app.MapGet("/api/todos/{id}", async ([FromRoute] int id) =>
            {
                var str = await todoService.GetOneAsync(id);
                if (str is null) return Results.NotFound();
                var todo = JsonConvert.DeserializeObject<Todo>(str);
                return Results.Ok(todo);
            }).WithName("Todo");
             
            app.MapPost("/api/todos", async() =>
            {
                TodoDto todo = new TodoDto() { todo = "My todo",completed= false,userId =12 };
                var result = await todoService.CreateAsync(todo);
                if (result is null)
                {
                    return Results.NotFound();
                }
                var newTodo = JsonConvert.DeserializeObject<TodoDto>(result);
                return Results.Ok(newTodo);

            }).WithName("CreateTodo");

            app.MapPut("/api/todos/{id}", async ([FromRoute]int id, [FromBody]TodoDto todoDto) =>
            {
                var result = await todoService.UpdateAsync(todoDto, id);
                if (result is null )
                {
                    return Results.NotFound();
                }
                var todo = JsonConvert.DeserializeObject<TodoDto>(result);
                return Results.Ok(todo);
            }).WithName("UpdateTodo");

            app.MapDelete("/api/todos/{id}", async ([FromRoute]int id) =>
            {
                var result = await todoService.DeleteAsync(id);
                if (result is null)
                {
                    return Results.BadRequest();
                }
                var deletTodo = JsonConvert.DeserializeObject<TodoDto>(result);
                return Results.Ok(deletTodo);
            }).WithName("DeleteTodo");
        }
    }
}
