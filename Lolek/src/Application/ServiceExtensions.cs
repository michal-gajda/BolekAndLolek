namespace Lolek.Application;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var featureManager = new FeatureManager(new ConfigurationFeatureDefinitionProvider(configuration))
        {
            FeatureFilters = new List<IFeatureFilterMetadata> { new FluentValidationFilter() }
        };

        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(cfg =>
        {
        }, assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        services.AddValidatorsFromAssembly(assembly);
    }
}
