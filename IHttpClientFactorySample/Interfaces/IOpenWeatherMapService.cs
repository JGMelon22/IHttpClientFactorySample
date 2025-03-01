using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Shared;

namespace IHttpClientFactorySample.Interfaces;

public interface IOpenWeatherMapService
{
    Task<Result<RootResponse>> GetCurrentWeatherByCityAsync(string city, string units = "standard");
}