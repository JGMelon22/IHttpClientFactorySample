using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Infrastructure.Services;
using IHttpClientFactorySample.Interfaces;
using Microsoft.Extensions.Options;

namespace IHttpClientFactorySample.Extensions;

public static class IocExtensions
{
    public static IServiceCollection AddOpenWeatherMapApiClient(this IServiceCollection services)
    {
        services.AddHttpClient("OpenWeatherMapApi")
            .ConfigureHttpClient((serviceProvider, client) =>
                {
                    OpenWeatherMapApiConfiguration weatherConfig = serviceProvider.GetRequiredService<IOptions<OpenWeatherMapApiConfiguration>>().Value;
                    client.BaseAddress = new Uri(weatherConfig.BaseUrl);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });

        services.AddTransient<IOpenWeatherMapService, OpenWeatherMapService>();

        return services;
    }
}
