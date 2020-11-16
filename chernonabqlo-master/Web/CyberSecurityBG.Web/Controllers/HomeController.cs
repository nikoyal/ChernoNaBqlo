namespace CyberSecurityBG.Web.Controllers
{
    using System.Diagnostics;
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
            var viewModel = new NewsPageViewModel();
            var news = this.newsService.GetAll<NewsViewModel>("politics");

            viewModel.News = news;
            return this.View(viewModel);
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
