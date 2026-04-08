using BirdApi.EndPonts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseBirdEndPoint();


app.Run();
