using Catalogues.Data;
using Catalogues.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

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

        public async Task GenerateAndDownloadTXTFile()
        {
            var sb = new StringBuilder();
            sb.AppendLine(await CataloguesRepository.DBToString());

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var stream = new MemoryStream(bytes);

            Response.Headers.Add("Content-Disposition", "attachment; filename=test.txt");
            Response.ContentType = "text/plain";
            stream.CopyTo(Response.Body);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string data = await reader.ReadToEndAsync();
                    CataloguesRepository.ClearDBAndImportFromStringToDB(data);
                }
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}