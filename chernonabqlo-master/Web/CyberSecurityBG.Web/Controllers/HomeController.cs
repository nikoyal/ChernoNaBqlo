namespace CyberSecurityBG.Web.Controllers
{
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels;
    using CyberSecurityBG.Web.ViewModels.Newss;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {

        private readonly INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All", "News", new {category = "Всички"});
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
