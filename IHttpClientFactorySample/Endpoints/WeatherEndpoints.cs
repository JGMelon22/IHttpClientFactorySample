using System.Threading.Tasks;
using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;
using IHttpClientFactorySample.Interfaces;

namespace IHttpClientFactorySample.Endpoints;

public static class WeatherEndpoints
{
    public static void MapWeatherRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", GetWeather)
        .WithName("GetCurrentWeatherInformation")
         .WithOpenApi();
    }

    /// <summary>
    /// Gets the current weather information for a specified city.
    /// </summary>
    /// <param name="city">The name of the city to get weather information for.</param>
    /// <param name="weatherService">The weather service to use for fetching data.</param>
    /// <param name="units">The units of measurement for the weather data (standard, metric, imperial).</param>
    /// <returns>The current weather information for the specified city.</returns>
    /// <response code="200">Returns the weather information if found.</response>
    /// <response code="400">Returns if there is an error in the request.</response>
    /// <response code="404">Returns if the city is not found.</response>
    private static async Task<IResult> GetWeather(string city, IOpenWeatherMapService weatherService, string units = "standard")
    {
        Result<RootResponse> result = await weatherService.GetCurrentWeatherByCityAsync(city, units);

        if (result is null)
        {
            return Results.NotFound($"Weather information for '{city}' not found.");
        }

        return result.IsSuccess != false
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}