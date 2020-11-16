namespace CyberSecurityBG.Services.Data
{
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Web.ViewModels;
    using CyberSecurityBG.Web.ViewModels.Newss;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly IUserService userService;

        private readonly IDeletableEntityRepository<RSSChannel> rrsRepository;

        public NewsController(INewsService newsService, IUserService userService, IDeletableEntityRepository<RSSChannel> rrsRepository)
        {
            this.newsService = newsService;
            this.userService = userService;
            this.rrsRepository = rrsRepository;
        }

        public async Task<IActionResult> ById(int id)
        {
            var viewModel = this.newsService.GetById<NewsViewModel>(id);
            await this.newsService.IncrementViews(id);
            foreach (var comment in viewModel.NewsComments)
            {
                comment.ProfilePicture = this.userService.GetProfilePicture(comment.UserUserName);
            }

            return this.View(viewModel);
        }

        public IActionResult All(string category)
        {
            var viewModel = new NewsPageViewModel();
            var news = this.newsService.GetAll<NewsViewModel>(category);

            viewModel.News = news;
            return this.View(viewModel);
        }


    }
}
