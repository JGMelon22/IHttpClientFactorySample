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
    ///     Gets the current weather information for a specified city.
    /// </summary>
    /// <param name="city">The name of the city to get weather information for.</param>
    /// <param name="weatherService">The weather service to use for fetching data.</param>
    /// <param name="units">The units of measurement for the weather data (standard, metric, imperial).</param>
    /// <returns>The current weather information for the specified city.</returns>
    /// <response code="200">Returns the weather information if found.</response>
    /// <response code="400">Returns if there is an error in the request.</response>
    /// <response code="404">Returns if the city is not found.</response>
    /// <remarks>
    /// ### Example Response
    ///
    /// ```json
    /// {
    ///   "data": {
    ///     "coord": {
    ///       "lon": -43.2075,
    ///       "lat": -22.9028
    ///     },
    ///     "weather": [
    ///       {
    ///         "id": 802,
    ///         "main": "Clouds",
    ///         "description": "scattered clouds",
    ///         "icon": "03d"
    ///       }
    ///     ],
    ///     "base": "stations",
    ///     "main": {
    ///       "temp": 30.64,
    ///       "feels_like": 33.43,
    ///       "temp_min": 29.98,
    ///       "temp_max": 32,
    ///       "pressure": 1014,
    ///       "humidity": 57,
    ///       "sea_level": 1014,
    ///       "grnd_level": 1016
    ///     },
    ///     "visibility": 10000,
    ///     "wind": {
    ///       "speed": 7.72,
    ///       "deg": 190
    ///     },
    ///     "clouds": {
    ///       "all": 40
    ///     },
    ///     "dt": 1740861100,
    ///     "sys": {
    ///       "type": 2,
    ///       "id": 2098643,
    ///       "country": "BR",
    ///       "sunrise": 1740818938,
    ///       "sunset": 1740864099
    ///     },
    ///     "timezone": -10800,
    ///     "id": 3451190,
    ///     "name": "Rio de Janeiro",
    ///     "cod": 200
    ///   },
    ///   "isSuccess": true,
    ///   "message": "Success"
    /// }
    /// ```
    /// </remarks>
    private static async Task<IResult> GetWeather(string city, IOpenWeatherMapService weatherService,
        string units = "standard")
    {
        Result<RootResponse> result = await weatherService.GetCurrentWeatherByCityAsync(city, units);

        if (result is null) return Results.NotFound($"Weather information for '{city}' not found.");

        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}
