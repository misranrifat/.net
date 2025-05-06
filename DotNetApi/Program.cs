using Microsoft.EntityFrameworkCore;
using DotNetApi.Data;
using DotNetApi.Repositories;
using System.Linq;
using System;

var builder = WebApplication.CreateBuilder(args);

// Set default URLs
builder.WebHost.UseUrls("http://localhost:8080", "https://localhost:8081");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseInMemoryDatabase("ProductsDb"));

// Add Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Print URLs the application is listening on
Console.WriteLine("Application URLs:");
foreach (var address in app.Urls)
{
    Console.WriteLine($"  {address}");
}
Console.WriteLine($"Swagger UI should be available at: {app.Urls.FirstOrDefault()}/swagger");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    // Add some sample data
    if (!context.Products.Any())
    {
        context.Products.Add(new DotNetApi.Models.Product { Name = "Product 1", Description = "Description for product 1", Price = 19.99m });
        context.Products.Add(new DotNetApi.Models.Product { Name = "Product 2", Description = "Description for product 2", Price = 29.99m });
        context.Products.Add(new DotNetApi.Models.Product { Name = "Product 3", Description = "Description for product 3", Price = 39.99m });
        context.SaveChanges();
    }
}

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
