namespace IHttpClientFactorySample.Domains.Entities;

public class Clouds
{
    public Clouds()
    {
    }

    public Clouds(int all)
    {
        All = all;
    }

    public int All { get; set; }
}