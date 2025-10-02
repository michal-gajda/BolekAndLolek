namespace Bolek.Infrastructure.Lolek;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceExtensions
{
    public static IServiceCollection AddLolek(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
