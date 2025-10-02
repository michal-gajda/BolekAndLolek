namespace Lolek.WebApi;

using Lolek.Application;
using Lolek.Infrastructure;
using Lolek.Infrastructure.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

public class Program
{
    private const int EXIT_SUCCESS = 0;

    public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplication(builder.Configuration);
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers().AddOData(odataOptions =>
        {
            const int DEFAULT_MAX_TOP = 200;

            IEdmModel edmModel = BuildEdmModel();

            odataOptions
                .Select()
                .Filter()
                .OrderBy()
                .Expand()
                .Count()
                .SetMaxTop(DEFAULT_MAX_TOP)
                .AddRouteComponents("odata", edmModel);
        });

        builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();

        return EXIT_SUCCESS;
    }

    static IEdmModel BuildEdmModel()
    {
        var modelBuilder = new ODataConventionModelBuilder();

        var weatherForecasts = modelBuilder.EntitySet<WeatherForecast>("WeatherForecasts");
        weatherForecasts.EntityType.HasKey(w => w.Date);

        return modelBuilder.GetEdmModel();
    }
}
