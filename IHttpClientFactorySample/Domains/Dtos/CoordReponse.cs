namespace IHttpClientFactorySample.Domains.Dtos;

public class CoordReponse
{
    public CoordReponse() { }

    public CoordReponse(double lon, double lat)
    {
        Lon = lon;
        Lat = lat;
    }

    public double Lon { get; set; }
    public double Lat { get; set; }
}
