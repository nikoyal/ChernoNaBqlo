namespace CyberSecurityBG.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class NewsService : INewsService
    {
            private readonly IDeletableEntityRepository<News> newsRepository;

            public NewsService(IDeletableEntityRepository<News> newsRepository)
            {
                this.newsRepository = newsRepository;
            }

        public IEnumerable<T> GetAll<T>(string category, int? count = null)
        {
            IQueryable<News> query = this.newsRepository.All().Where(x => x.Category == category).OrderBy(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(string title, string content, string url, string category)
        {
            var news = new News
            {
                Title = title,
                Content = content,
                PictureUrl = url,
                Category = category,
                CreatedOn = DateTime.UtcNow,
            };
            await this.newsRepository.AddAsync(news);
            await this.newsRepository.SaveChangesAsync();
            return news.Id;
        }


        public T GetById<T>(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return news;
        }

        public async Task<bool> IncrementViews(int id)
        {
            this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault().Views += 1;
            await this.newsRepository.SaveChangesAsync();
            return true;
        }
    }
}
