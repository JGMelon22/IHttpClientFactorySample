using System.Text.Json.Serialization;

namespace IHttpClientFactorySample.Domains.Dtos;

public class MainResponse
{
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; set; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }


    [JsonPropertyName("grnd_level")]
    public int GrndLevel { get; set; }

    public MainResponse() { }

    public MainResponse(double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity, int seaLevel, int grndLevel)
    {
        Temp = temp;
        FeelsLike = feelsLike;
        TempMin = tempMin;
        TempMax = tempMax;
        Pressure = pressure;
        Humidity = humidity;
        SeaLevel = seaLevel;
        GrndLevel = grndLevel;
    }
}

