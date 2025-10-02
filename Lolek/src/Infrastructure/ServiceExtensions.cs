namespace Lolek.Infrastructure;

using System.Reflection;
using FluentValidation;
using Lolek.Infrastructure.Interfaces;
using Lolek.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(cfg =>
        {
        }, assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        services.AddValidatorsFromAssembly(assembly);

        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
    }
}
