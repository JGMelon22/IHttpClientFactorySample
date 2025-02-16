namespace IHttpClientFactorySample.Domains.Entities;

public class Coord
{
    public Coord() { }

    public Coord(double lon, double lat)
    {
        Lon = lon;
        Lat = lat;
    }

    public double Lon { get; set; }
    public double Lat { get; set; }
}
