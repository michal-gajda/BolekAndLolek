namespace Bolek.WebApi;

using Application;
using Infrastructure;

public class Program
{
    private const int EXIT_SUCCESS = 0;

    private const string SERVICE_NAME = "bolek-webapi";
    private const string SERVICE_NAMESPACE = "bolek-and-lolek";
    private const string SERVICE_VERSION = "poc";

    public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHealthChecks();
        builder.Services.AddObservability(SERVICE_NAME, SERVICE_NAMESPACE, SERVICE_VERSION);

        builder.Services.AddApplication(builder.Configuration);
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();

        return EXIT_SUCCESS;
    }
}
