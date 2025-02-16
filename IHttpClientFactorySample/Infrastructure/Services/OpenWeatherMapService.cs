using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;
using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace IHttpClientFactorySample.Infrastructure.Services;

public class OpenWeatherMapService : IOpenWeatherMapService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpenWeatherMapService> _logger;
    private readonly string _apiKey;

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
        try
        {
            Dictionary<string, string?> queryParams = new()
            {
                ["q"] = city,
                ["units"] = units,
                ["appid"] = _apiKey
            };

            string url = QueryHelpers.AddQueryString("weather", queryParams);

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            RootResponse? data = await response.Content.ReadFromJsonAsync<RootResponse>();
            if (data is null)
            {
                return Result<RootResponse>.Failure("Failed to deserialize response.");
            }

            return Result<RootResponse>.Success(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while trying to fetch data from OpenWeatherMapAPI");
            return Result<RootResponse>.Failure("An error occurred while fetching weather data.");
        }
    }
}
