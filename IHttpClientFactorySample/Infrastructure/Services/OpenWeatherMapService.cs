using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;
using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace IHttpClientFactorySample.Infrastructure.Services;

public class OpenWeatherMapService : IOpenWeatherMapService
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpenWeatherMapService> _logger;

    public OpenWeatherMapService(HttpClient httpClient,
        ILogger<OpenWeatherMapService> logger,
        IOptions<OpenWeatherMapApiConfiguration> options)
    {
        _httpClient = httpClient;
        _logger = logger;
        _apiKey = options.Value.ApiKey;
    }

    public async Task<Result<RootResponse>> GetCurrentWeatherByCityAsync(string city, string units)
    {
        _logger.LogInformation("Starting Executing: {ClassName}.{MethodName}, City: {City}, Units: {Units}",
            typeof(OpenWeatherMapService).Name,
            nameof(GetCurrentWeatherByCityAsync),
            city,
            units);
        try
        {
            Dictionary<string, string?> queryParams = new()
            {
                ["q"] = city,
                ["units"] = units,
                ["appid"] = _apiKey
            };

            var url = QueryHelpers.AddQueryString("weather", queryParams);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<RootResponse>();
            return data != null
                ? Result<RootResponse>.Success(data)
                : Result<RootResponse>.Failure("Failed to deserialize response.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while trying to fetch data from OpenWeatherMapAPI");
            return Result<RootResponse>.Failure("An error occurred while fetching weather data.");
        }
    }
}