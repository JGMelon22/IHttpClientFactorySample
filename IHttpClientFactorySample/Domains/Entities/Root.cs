namespace IHttpClientFactorySample.Domains.Entities;

public class Root
{
    public Coord Coord { get; set; }
    public List<Weather> Weather { get; set; }
    public string Base { get; set; }
    public Main Main { get; set; }
    public int Visibility { get; set; }
    public Wind Wind { get; set; }
    public Clouds Clouds { get; set; }
    public int Dt { get; set; }
    public Sys Sys { get; set; }
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cod { get; set; }

    public Root() { }

    public Root(Coord coord, List<Weather> weather, string @base, Main main, int visibility, Wind wind, Clouds clouds, int dt, Sys sys, int timezone, int id, string name, int cod)
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
