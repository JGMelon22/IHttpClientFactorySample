using System.Net.Http.Json;
using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Infrastructure.Configurations;
using IHttpClientFactorySample.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using IHttpClientFactorySample.Domains.Shared;
using Shouldly;
using IHttpClientFactorySample.Interfaces;

namespace IHttpClientFactorySample.Tests.Infrastructure.Services;

public class OpenWeatherMapServiceTests
{
    [Fact]
    public async Task Should_ReturnSuccessResult_When_WeatherDataIsFetchedSuccessfully()
    {
        // Arrange
        Mock<HttpMessageHandler> httpMessageHandlerMock = new();

        HttpResponseMessage responseMessage = new(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(new RootResponse
            {
                Coord = new CoordResponse
                {
                    Lon = -0.1257,
                    Lat = 51.5085
                },
                Weather = new List<WeatherResponse>
                    {
                        new WeatherResponse
                        {
                            Id = 804,
                            Main = "Clouds",
                            Description = "overcast clouds",
                            Icon = "04n"
                        }
                    },
                Base = "stations",
                Main = new MainResponse
                {
                    Temp = 2.82,
                    FeelsLike = -1.19,
                    TempMin = 1.4,
                    TempMax = 3.38,
                    Pressure = 1022,
                    Humidity = 75,
                    SeaLevel = 1022,
                    GrndLevel = 1018
                },
                Visibility = 10000,
                Wind = new WindResponse
                {
                    Speed = 4.63,
                    Deg = 90
                },
                Clouds = new CloudsResponse
                {
                    All = 100
                },
                Dt = 1739739420,
                Sys = new SysResponse
                {
                    Type = 2,
                    Id = 2075535,
                    Country = "GB",
                    Sunrise = 1739689952,
                    Sunset = 1739726213
                },
                Timezone = 0,
                Id = 2643743,
                Name = "London",
                Cod = 200
            })
        };

        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(responseMessage);

        HttpClient httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
        };

        Mock<ILogger<OpenWeatherMapService>> loggerMock = new();
        IOptions<OpenWeatherMapApiConfiguration> options = Options.Create(new OpenWeatherMapApiConfiguration { ApiKey = "test-api-key" });

        IOpenWeatherMapService service = new OpenWeatherMapService(httpClient, loggerMock.Object, options);

        string city = "London";
        string units = "metric";

        // Act
        Result<RootResponse> result = await service.GetCurrentWeatherByCityAsync(city, units);

        // Assert
        result.ShouldNotBeNull();
        result.IsSuccess.ShouldBeTrue();
        result.Data.ShouldNotBeNull();
        result.Message.ShouldBe("Success");
    }

    [Fact]
    public async Task Should_ReturnFailureResult_When_ApiReturnsError()
    {
        // Arrange
        Mock<HttpMessageHandler> httpMessageHandlerMock = new();

        HttpResponseMessage responseMessage = new(HttpStatusCode.BadRequest)
        {
            Content = JsonContent.Create(new { message = "Bad Request" })
        };

        httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(responseMessage);

        HttpClient httpClient = new HttpClient(httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
        };

        Mock<ILogger<OpenWeatherMapService>> loggerMock = new();
        IOptions<OpenWeatherMapApiConfiguration> options = Options.Create(new OpenWeatherMapApiConfiguration { ApiKey = "test-api-key" });

        IOpenWeatherMapService service = new OpenWeatherMapService(httpClient, loggerMock.Object, options);

        string city = "London";
        string units = "metric";

        // Act
        Result<RootResponse> result = await service.GetCurrentWeatherByCityAsync(city, units);

        // Assert
        result.ShouldNotBeNull();
        result.IsSuccess.ShouldBeFalse();
        result.Data.ShouldBeNull();
        result.Message.ShouldBe("An error occurred while fetching weather data.");
    }
}
