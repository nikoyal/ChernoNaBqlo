namespace CyberSecurityBG.Services.Data
{
    using System.Threading.Tasks;

    public interface INewsCommentService
    {
        Task Create(int newsId, string userId, string content);
    }
}
