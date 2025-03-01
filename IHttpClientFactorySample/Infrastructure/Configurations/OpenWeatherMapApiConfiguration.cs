namespace IHttpClientFactorySample.Infrastructure.Configurations;

public class OpenWeatherMapApiConfiguration
{
    public const string SectionName = "OpenWeatherMapApi";

    public string BaseUrl { get; init; } = string.Empty;
    public string ApiKey { get; init; } = string.Empty;
}