namespace Tola.WebUI.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Models;


public sealed class HomeController : Controller
{
    public IActionResult Index()
    {
        return base.View();
    }

    public IActionResult Privacy()
    {
        return base.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var viewModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        };

        return base.View(viewModel);
    }
}
