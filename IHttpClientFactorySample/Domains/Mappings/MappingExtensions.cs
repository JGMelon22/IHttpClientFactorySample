using IHttpClientFactorySample.Domains.Dtos;
using IHttpClientFactorySample.Domains.Entities;

namespace IHttpClientFactorySample.Domains.Mappings;

public static class MappingExtensions
{
    public static RootResponse ToResponse(this Root root)
    {
        return new RootResponse
        {
            Coord = new CoordReponse
            {
                Lon = root.Coord.Lon,
                Lat = root.Coord.Lat
            },
            Weather = root.Weather
                .Select(w => new WeatherResponse
                {
                    Id = w.Id,
                    Main = w.Main,
                    Description = w.Description,
                    Icon = w.Icon
                })
                .ToList(),
            Base = root.Base,
            Main = new MainResponse
            {
                Temp = root.Main.Temp,
                FeelsLike = root.Main.FeelsLike,
                TempMin = root.Main.TempMin,
                TempMax = root.Main.TempMax,
                Pressure = root.Main.Pressure,
                Humidity = root.Main.Humidity,
                SeaLevel = root.Main.SeaLevel,
                GrndLevel = root.Main.GrndLevel
            },
            Visibility = root.Visibility,
            Wind = new WindResponse
            {
                Speed = root.Wind.Speed,
                Deg = root.Wind.Deg
            },
            Clouds = new CloudsResponse
            {
                All = root.Clouds.All
            },
            Dt = root.Dt,
            Sys = new SysResponse
            {
                Type = root.Sys.Type,
                Id = root.Sys.Id,
                Country = root.Sys.Country,
                Sunrise = root.Sys.Sunrise,
                Sunset = root.Sys.Sunset
            },
            Timezone = root.Timezone,
            Id = root.Id,
            Name = root.Name,
            Cod = root.Cod
        };
    }
}
