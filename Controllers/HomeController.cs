using Catalogues.Data;
using Catalogues.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Catalogues.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string name)
        {
            if(name == null)
            {
                return View(await CataloguesRepository.GetCatalogueAsync("Creating Digital Images"));
            }
            else
            {
                return View(await CataloguesRepository.GetCatalogueAsync(name));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}