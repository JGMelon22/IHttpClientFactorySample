namespace IHttpClientFactorySample.Domains.Dtos;

public record WeatherResponse
{
    public int Id { get; init; }
    public string Main { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}