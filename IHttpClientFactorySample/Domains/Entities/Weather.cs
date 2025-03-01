namespace IHttpClientFactorySample.Domains.Entities;

public class Weather
{
    public int Id { get; set; }
    public string Main { get; set; } = string.Empty;
    public string Description { get; set; }=string.Empty;
    public string Icon { get; set; }=string.Empty;

    public Weather()
    {
    }

    public Weather(int id, string main, string description, string icon)
    {
        Id = id;
        Main = main;
        Description = description;
        Icon = icon;
    }
}
