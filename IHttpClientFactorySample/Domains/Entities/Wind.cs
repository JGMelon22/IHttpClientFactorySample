namespace IHttpClientFactorySample.Domains.Entities;

public class Wind
{
    public double Speed { get; set; }
    public int Deg { get; set; }

    public Wind() { }

    public Wind(double speed, int deg)
    {
        Speed = speed;
        Deg = deg;
    }
}
