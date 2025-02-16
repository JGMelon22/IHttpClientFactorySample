namespace IHttpClientFactorySample.Domains.Dtos;

public class CloudsResponse
{
    public int All { get; set; }

    public CloudsResponse() { }

    public CloudsResponse(int all)
    {
        All = all;
    }
}
