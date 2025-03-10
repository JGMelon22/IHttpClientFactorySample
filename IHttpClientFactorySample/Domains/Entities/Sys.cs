namespace IHttpClientFactorySample.Domains.Entities;

public class Sys
{
    public Sys()
    {
    }

    public Sys(int type, int id, string country, int sunrise, int sunset)
    {
        Type = type;
        Id = id;
        Country = country;
        Sunrise = sunrise;
        Sunset = sunset;
    }

    public int Type { get; set; }
    public int Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public int Sunrise { get; set; }
    public int Sunset { get; set; }
}