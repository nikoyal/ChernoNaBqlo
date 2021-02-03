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

        public IEnumerable<T> GetAll<T>(string category, int? take = null, int skip = 0)
        {
            if (category == "Всички")
            {
                //tofix take by amount
                IQueryable<News> queryall = this.newsRepository.All().OrderByDescending(x => x.CreatedOn).Skip(skip);
                if (take.HasValue)
                {
                    queryall = queryall.Take(take.Value);
                }
                return queryall.To<T>().ToList();
            }
            IQueryable<News> query = this.newsRepository.All().Where(x => x.Category == category).OrderByDescending(x => x.CreatedOn).Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(string title, string content, string url, string category, string datestr, bool createdbyadmin, string source)
        {
            DateTime date;
            if (datestr == null)
            {
                date = DateTime.UtcNow;
            }
            else
            {
                date = DateTime.Parse(datestr);
            }

            var currentdata = this.newsRepository.All().Where(x => x.Title == title).FirstOrDefault();
            if (currentdata == null)
            {
                var news = new News
                {
                    Title = title,
                    Content = content,
                    PictureUrl = url,
                    Category = category,
                    CreatedOn = date,
                    CreatedByAdmin = createdbyadmin,
                    Source = source,
                };
                await this.newsRepository.AddAsync(news);
                await this.newsRepository.SaveChangesAsync();
                return news.Id;
            }

            return currentdata.Id;
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

        public IEnumerable<T> GetTop<T>(int id)
        {
            //to fix to true when more admin news maybe
            IQueryable<News> topnews = this.newsRepository.All().Where(x => x.Id != id).Take(5).OrderByDescending(x => x.Views);
            return topnews.To<T>().ToList();
        }

        public int GetCountByCategory(string category)
        {
            if(category == "Всички")
            {
                return this.newsRepository.All().Count();
            }
            return this.newsRepository.All().Count(x => x.Category == category);
        }
    }
}
