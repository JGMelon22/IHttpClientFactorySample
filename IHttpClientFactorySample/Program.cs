using System.Reflection;
using IHttpClientFactorySample.Endpoints;
using IHttpClientFactorySample.Extensions;
using IHttpClientFactorySample.Infrastructure.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "OpenWeather External Api Consumer",
        Description = "An ASP.NET Core Web API for check weather information with OpenWeather"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddOpenWeatherMapApiClient();
builder.Services.Configure<OpenWeatherMapApiConfiguration>(options => builder.Configuration
    .GetSection("OpenWeatherMapApi")
    .Bind(options));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapWeatherRoutes();

app.Run();