using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;
using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Interfaces;
using Microsoft.Extensions.Options;

namespace IHttpClientFactorySample.Infrastructure.Services;

public class OpenWeatherMapService : IOpenWeatherMapService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<OpenWeatherMapService> _logger;
    private readonly string _apiKey;
    private const string ClientName = "OpenWeatherMapApi";

    public OpenWeatherMapService(IHttpClientFactory httpClientFactory,
        ILogger<OpenWeatherMapService> logger,
        IOptions<OpenWeatherMapApiConfiguration> options)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _apiKey = options.Value.ApiKey;
    }

    public async Task<Result<RootResponse>> GetCurrentWeatherByCityAsync(string city, string units = "standard")
    {
        try
        {
            HttpClient httpClient = _httpClientFactory.CreateClient(ClientName);
            HttpResponseMessage response = await httpClient.GetAsync($"weather?q={city}&units={units}&appid={_apiKey}");
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
