using BirdApi.Models;
using Newtonsoft.Json;

namespace BirdApi.EndPonts
{
    public static class TodoEndPoint
    {
        public static void UseTodoEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/todos", () =>
            {
                string todosStr = File.ReadAllText("Data/Todos.json");
                var todos = JsonConvert.DeserializeObject<List<Todo>>(todosStr);
                if ( todos is null || todos.Count <= 0 )
                {
                    return Results.NotFound();
                }
                return Results.Ok(todos);
            }).WithName("Todos");
        }
    }
}
