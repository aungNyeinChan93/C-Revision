using DatabaseTwo.Models;
using Domain_01.Features;
using Domain_02.Services;
using Microsoft.EntityFrameworkCore;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
},ServiceLifetime.Transient,ServiceLifetime.Transient);

//builder.Services.AddScoped<IQuoteService,QuoteService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IQuoteService,QuoteService2>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
