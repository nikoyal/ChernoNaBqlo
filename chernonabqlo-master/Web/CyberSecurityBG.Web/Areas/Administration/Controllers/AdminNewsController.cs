namespace CyberSecurityBG.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using CyberSecurityBG.Common;
    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels;
    using CyberSecurityBG.Web.ViewModels.Newss;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdminNewsController : Controller
    {
        private readonly INewsService newsService;

        private readonly IDeletableEntityRepository<News> newsRepository;

        private readonly IDeletableEntityRepository<RSSChannel> rssRepository;

        public AdminNewsController(
            INewsService newsService,
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<RSSChannel> rssRepository)
        {
            this.newsService = newsService;
            this.newsRepository = newsRepository;
            this.rssRepository = rssRepository;
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

        public IActionResult GetEditById(int id)
        {
            var viewData = this.newsService.GetById<NewsViewModel>(id);
            return this.View(viewData);
        }

        public async Task<IActionResult> EditById(int id, string url, string title, string content)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            news.Title = title;
            news.Content = content;
            news.PictureUrl = url;
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", "News", new { id = news.Id, area = string.Empty });
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new NewsCreateInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(NewsCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var newsId = await this.newsService.CreateAsync(input.Title, input.Content, input.Url, input.Category, null, true, "");

            return this.RedirectToAction("ById", "News", new { id = newsId, area = string.Empty });
        }

        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

        //public IActionResult Rssfeed()
        //{
        //    return this.View();
        //}

        [HttpPost]
        public IActionResult Rssfeed()
        {
            this.CreateRSSNewsWithCategory();
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        public void CreateRSSNewsWithCategory()
        {
            WebClient wclient = new WebClient();
            var rssurls = this.rssRepository.All().Where(x => x.Id == 1016).FirstOrDefault();
            string rssData = wclient.DownloadString(rssurls.URL);
            XDocument xml = XDocument.Parse(rssData);
            var regex = new Regex("/\\d+/");
            var rssFeedData = from x in xml.Descendants("item")
                                  select new RSSFeed
                                  {
                                      Title = (string)x.Element("title"),
                                      Source = (string)x.Element("link"),
                                      Description = Regex.Replace((string)x.Element("description").Value, @"<.*>", string.Empty),
                                      PubDate = (string)x.Element("pubDate"),
                                      PictureUrl = Regex.Match((string)x.Element("description").Value, @"https\S+.jpg").ToString(),
                                      Category = (string)x.Element("category"),
                                  };

            foreach (var data in rssFeedData)
            {
                if (data.Category != "Свят" && data.Category != "България" && data.Category != "Бизнес" && data.Category != "Коронавирус" && data.Category != "Европа")
                {
                    data.Category = "Други";
                }

                this.newsService.CreateAsync(data.Title, data.Description, data.PictureUrl, data.Category, data.PubDate, false, data.Source);
                }

        }

    }
}
