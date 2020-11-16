namespace CyberSecurityBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsService
    {
        Task<int> CreateAsync(string title, string content, string url, string category);

        T GetById<T>(int id);

        Task<bool> IncrementViews(int id);

        IEnumerable<T> GetAll<T>(string category, int? count = null);
    }

}

