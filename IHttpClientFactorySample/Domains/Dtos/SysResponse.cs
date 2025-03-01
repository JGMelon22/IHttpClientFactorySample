namespace IHttpClientFactorySample.Domains.Dtos;

public record SysResponse
{
    public int Type { get; init; }
    public int Id { get; init; }
    public string Country { get; init; } = string.Empty;
    public int Sunrise { get; init; }
    public int Sunset { get; init; }
}