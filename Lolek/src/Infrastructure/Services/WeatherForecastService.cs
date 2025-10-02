namespace  Lolek.Infrastructure.Services;

using System.Linq;
using Lolek.Infrastructure.Interfaces;
using Lolek.Infrastructure.Models;

internal sealed class WeatherForecastService : IWeatherForecastService
{
    private readonly Dictionary<DateOnly, WeatherForecast> forecasts = new();

    private static readonly string[] Summaries =
    [
        "Balmy",
        "Bracing",
        "Chilly",
        "Cool",
        "Freezing",
        "Hot",
        "Mild",
        "Scorching",
        "Sweltering",
        "Warm",
    ];

    public WeatherForecastService(TimeProvider timeProvider)
    {
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(timeProvider.GetUtcNow().Date.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        foreach (var forecast in forecasts)
        {
            this.forecasts[forecast.Date] = forecast;
        }
    }

    public WeatherForecast? FindByDate(DateOnly date)
    {
        forecasts.TryGetValue(date, out var forecast);

        return forecast;
    }

    public IQueryable<WeatherForecast> Queryable()
    {
        return forecasts.Values.AsQueryable();
    }

    public void Update(WeatherForecast weatherForecast)
    {
        forecasts[weatherForecast.Date] = weatherForecast;
    }
}
