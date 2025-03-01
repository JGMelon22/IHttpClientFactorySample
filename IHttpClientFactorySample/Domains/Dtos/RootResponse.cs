namespace IHttpClientFactorySample.Domains.Dtos;

public class RootResponse
{
    public CoordResponse Coord { get; set; }
    public List<WeatherResponse> Weather { get; set; }
    public string Base { get; set; }
    public MainResponse Main { get; set; }
    public int Visibility { get; set; }
    public WindResponse Wind { get; set; }
    public CloudsResponse Clouds { get; set; }
    public int Dt { get; set; }
    public SysResponse Sys { get; set; }
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cod { get; set; }

    public RootResponse() { }

    public RootResponse(CoordResponse coord, List<WeatherResponse> weather, string @base, MainResponse main, int visibility, WindResponse wind, CloudsResponse clouds, int dt, SysResponse sys, int timezone, int id, string name, int cod)
    {
        Coord = coord;
        Weather = weather;
        Base = @base;
        Main = main;
        Visibility = visibility;
        Wind = wind;
        Clouds = clouds;
        Dt = dt;
        Sys = sys;
        Timezone = timezone;
        Id = id;
        Name = name;
        Cod = cod;
    }
}
