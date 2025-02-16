namespace IHttpClientFactorySample.Domains.Dtos;

public class WeatherResponse
{
    public int Id { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }

    public WeatherResponse()
    {
    }

    public WeatherResponse(int id, string main, string description, string icon)
    {
        Id = id;
        Main = main;
        Description = description;
        Icon = icon;
    }
}
