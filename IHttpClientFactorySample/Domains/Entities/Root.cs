namespace IHttpClientFactorySample.Domains.Entities;

public class Root
{
    public Root()
    {
    }

    public Root(Coord coord, List<Weather> weather, string @base, Main main, int visibility, Wind wind, Clouds clouds,
        int dt, Sys sys, int timezone, int id, string name, int cod)
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

    public Coord Coord { get; set; } = new();
    public IEnumerable<Weather> Weather { get; set; } = new List<Weather>();
    public string Base { get; set; } = string.Empty;
    public Main Main { get; set; } = new();
    public int Visibility { get; set; }
    public Wind Wind { get; set; } = new();
    public Clouds Clouds { get; set; } = new();
    public int Dt { get; set; }
    public Sys Sys { get; set; } = new();
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Cod { get; set; }
}