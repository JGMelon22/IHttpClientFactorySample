namespace IHttpClientFactorySample.Domains.Dtos;

public record WindResponse
{
    public double Speed { get; init; }
    public int Deg { get; init; }
}
