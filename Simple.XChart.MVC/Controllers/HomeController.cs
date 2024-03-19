using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Simple.XChart.MVC.Models;
using Simple.XChart.MVC.Models.Views;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Helpers;
using System.Diagnostics;
using System.Drawing;

namespace Simple.XChart.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly RoLRepositoryHelper database;
        private readonly IAppCache cache;

        public HomeController(ILogger<HomeController> logger, RoLRepositoryHelper database, IAppCache cache)
        {
            this.logger = logger;
            this.database = database;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new IndexViewModel();
                model.image = await database.TryGetBannerImage();
                model.occurences = await database.GetOccurences();
                model.bannerTextColor = CalcBannerTextColor(model.image);
                
                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBannerAsync()
        {
            var image = await database.TryGetBannerImage();
            return Json(image);
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

        private string CalcBannerTextColor(BannerImage image)
        {
            var conv = new ColorConverter();
            var avgColor = (Color)conv.ConvertFromString(image.AverageColor);

            return (((avgColor.R + avgColor.B + avgColor.G) / 3) > 128) ? "text-black" : "text-white";
        }
    }
}
