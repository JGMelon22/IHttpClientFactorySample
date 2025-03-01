namespace IHttpClientFactorySample.Domains.Entities;

public class Main
{
    public Main()
    {
    }

    public Main(double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity, int seaLevel,
        int grndLevel)
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

    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public int SeaLevel { get; set; }
    public int GrndLevel { get; set; }
}