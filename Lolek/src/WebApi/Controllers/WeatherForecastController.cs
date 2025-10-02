namespace Lolek.WebApi.Controllers;

using Lolek.Infrastructure.Interfaces;
using Lolek.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

[Route("odata/[controller]")]
public sealed class WeatherForecastController(IWeatherForecastService weatherForecastService) : ODataController
{
    [EnableQuery]
    [HttpGet]
    public IQueryable<WeatherForecast> Get()
    {
        return weatherForecastService.Queryable();
    }

    [EnableQuery]
    [HttpGet("({date})")]
    public ActionResult<WeatherForecast> Get(DateOnly date)
    {
        var forecast = weatherForecastService.FindByDate(date);

        if (forecast is null)
        {
            return NotFound();
        }

        return Ok(forecast);
    }

    [HttpPatch("({date})")]
    public IActionResult Patch([FromODataUri] DateOnly date, [FromBody] Delta<WeatherForecast> patch)
    {
        var existingForecast = weatherForecastService.FindByDate(date);

        if (existingForecast is null)
        {
            return NotFound();
        }

        weatherForecastService.Update(patch.Patch(existingForecast));

        return NoContent();
    }
}
