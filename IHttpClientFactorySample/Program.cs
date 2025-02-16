using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;
using IHttpClientFactorySample.Extensions;
using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/weatherforecast/{city}", async (string city, string? units, IOpenWeatherMapService weatherService) =>
{
    Result<RootResponse> result = await weatherService.GetCurrentWeatherByCityAsync(city, units);

    if (result is null)
    {
        return Results.NotFound($"Weather information for '{city}' not found.");
    }

    return result.IsSuccess != false
        ? Results.Ok(result)
        : Results.BadRequest(result);
})
.WithName("GetCurrentWeatherInformation")
.WithOpenApi();

app.Run();
