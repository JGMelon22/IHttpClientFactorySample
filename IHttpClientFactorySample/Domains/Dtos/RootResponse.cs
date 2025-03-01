namespace IHttpClientFactorySample.Domains.Dtos;

public record RootResponse
{
    public CoordResponse Coord { get; init; } = new();
    public IEnumerable<WeatherResponse> Weather { get; init; } = new List<WeatherResponse>();
    public string Base { get; init; } = string.Empty;
    public MainResponse Main { get; init; } = new();
    public int Visibility { get; init; }
    public WindResponse Wind { get; init; } = new();
    public CloudsResponse Clouds { get; init; } = new();
    public int Dt { get; init; }
    public SysResponse Sys { get; init; } = new();
    public int Timezone { get; init; }
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Cod { get; init; }
}
