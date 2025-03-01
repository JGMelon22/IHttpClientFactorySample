namespace IHttpClientFactorySample.Domains.Dtos;

public record CoordResponse
{
    public double Lon { get; init; }
    public double Lat { get; init; }
}