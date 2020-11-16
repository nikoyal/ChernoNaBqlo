namespace CyberSecurityBG.Services.Data
{
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;

    public class NewsCommentService : INewsCommentService
    {
        private readonly IDeletableEntityRepository<NewsComment> newsRepository;

        public NewsCommentService(IDeletableEntityRepository<NewsComment> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task Create(int newsId, string userId, string content)
        {
            var comment = new NewsComment
            {
                NewsId = newsId,
                UserId = userId,
                Content = content,
            };
            await this.newsRepository.AddAsync(comment);
            await this.newsRepository.SaveChangesAsync();
        }
    }
}
