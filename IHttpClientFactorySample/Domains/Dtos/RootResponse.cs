namespace IHttpClientFactorySample.Domains.Dtos;

public record RootResponse
{
    public CoordResponse Coord { get; init; }
    public List<WeatherResponse> Weather { get; init; }
    public string Base { get; init; }
    public MainResponse Main { get; init; }
    public int Visibility { get; init; }
    public WindResponse Wind { get; init; }
    public CloudsResponse Clouds { get; init; }
    public int Dt { get; init; }
    public SysResponse Sys { get; init; }
    public int Timezone { get; init; }
    public int Id { get; init; }
    public string Name { get; init; }
    public int Cod { get; init; }
}
