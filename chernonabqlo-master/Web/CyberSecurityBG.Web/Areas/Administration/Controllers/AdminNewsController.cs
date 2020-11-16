namespace CyberSecurityBG.Web.Areas.Administration.Controllers
{
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

        private readonly IDeletableEntityRepository<RSSChannel> rrsRepository;

        public AdminNewsController(
            INewsService newsService,
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<RSSChannel> rrsRepository)
        {
            this.newsService = newsService;
            this.newsRepository = newsRepository;
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

            var newsId = await this.newsService.CreateAsync(input.Title, input.Content, input.Url, input.Category);

            return this.RedirectToAction("ById", "News", new { id = newsId, area = string.Empty });
        }

        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

        public IActionResult Rssfeed()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Rssfeed(string empty)
        {
            WebClient wclient = new WebClient();
            var rssurl = this.rrsRepository.All().Where(x => x.Id == 16).FirstOrDefault().URL;
            string RSSData = wclient.DownloadString(rssurl);

            XDocument xml = XDocument.Parse(RSSData);

            var regex = new Regex("/\\d+/");
            var RSSFeedData = from x in xml.Descendants("item")
                              select new RSSFeed
                              {
                                  Title = (string)x.Element("title"),
                                  Link = (string)x.Element("link"),
                                  Description = (string)x.Element("description"),
                                  PubDate = (string)x.Element("pubDate"),
                                  PictureUrl = (string)x.Element("enclosure").Attribute("url"),
                              };
            foreach (var data in RSSFeedData)
            {
                this.newsService.CreateAsync(data.Title, data.Description, data.PictureUrl, "Other");
                //    string PictureNumber = regex.Match(data.Link).ToString().TrimStart('/').TrimEnd('/');
                //    string PictureUrl = "https://presscenters.com/images/news/" + PictureNumber.Substring(PictureNumber.Length - 2) + "/big_" + PictureNumber + ".png";
            }

            this.ViewBag.RSSFeed = RSSFeedData;
            return this.View();
        }

    }
}
