using RestSharp;
using Tuto_09_MinimalApi.EndPoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(n => new HttpClient()
{ 
    BaseAddress = new Uri(builder.Configuration.GetSection("ApiEndPoint").Value!)
});

//builder.Services.AddScoped<RestClient>();
builder.Services.AddScoped( n =>new RestClient(baseUrl: builder.Configuration.GetSection("ApiEndPoint").Value!));

var app = builder.Build();

app.UsePost();
app.UseQuotes();

app.Run();
