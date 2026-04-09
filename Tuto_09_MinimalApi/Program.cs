using Tuto_09_MinimalApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(n => new HttpClient() { BaseAddress = new Uri(builder.Configuration.GetSection("ApiEndPoint").Value!) });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UsePost();

app.Run();
