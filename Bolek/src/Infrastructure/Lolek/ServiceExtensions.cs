namespace Bolek.Infrastructure.Lolek;

using Bolek.Infrastructure.Lolek.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceExtensions
{
    public static IServiceCollection AddLolek(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection(LolekOptions.SECTION_NAME).Get<LolekOptions>()!;

        services.AddTransient<AuthenticationDelegatingHandler>();

        services.AddHttpClient<LolekService>(client =>
        {
            client.BaseAddress = options.BaseAddress;
        })
        .AddHttpMessageHandler<AuthenticationDelegatingHandler>()
        ;

        return services;
    }
}
