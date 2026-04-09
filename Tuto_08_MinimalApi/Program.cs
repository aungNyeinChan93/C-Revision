using Tuto_08_MinimalApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseTodo();
app.UseRecipes();

app.Run();
