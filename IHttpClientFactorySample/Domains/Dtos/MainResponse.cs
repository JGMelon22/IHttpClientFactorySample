using System.Text.Json.Serialization;

namespace IHttpClientFactorySample.Domains.Dtos;

public record MainResponse
{
    public double Temp { get; init; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; init; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; init; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; init; }
    public int Pressure { get; init; }
    public int Humidity { get; init; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; init; }


    [JsonPropertyName("grnd_level")]
    public int GrndLevel { get; init; }
}

