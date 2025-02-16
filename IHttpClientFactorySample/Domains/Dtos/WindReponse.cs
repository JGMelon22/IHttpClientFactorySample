namespace IHttpClientFactorySample.Domains.Dtos;

public class WindResponse
{
    public double Speed { get; set; }
    public int Deg { get; set; }

    public WindResponse() { }

    public WindResponse(double speed, int deg)
    {
        Speed = speed;
        Deg = deg;
    }
}
