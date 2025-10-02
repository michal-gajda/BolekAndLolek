namespace Lolek.Infrastructure.Interfaces;

using Lolek.Infrastructure.Models;

public interface IWeatherForecastService
{
    IQueryable<WeatherForecast> Queryable();
    WeatherForecast? FindByDate(DateOnly date);
    void Update(WeatherForecast weatherForecast);
}
