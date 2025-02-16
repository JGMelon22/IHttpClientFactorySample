namespace IHttpClientFactorySample.Domains.Dtos;

public class SysResponse
{
    public int Type { get; set; }
    public int Id { get; set; }
    public string Country { get; set; }
    public int Sunrise { get; set; }
    public int Sunset { get; set; }

    public SysResponse() { }

    public SysResponse(int type, int id, string country, int sunrise, int sunset)
    {
        Type = type;
        Id = id;
        Country = country;
        Sunrise = sunrise;
        Sunset = sunset;
    }
}
