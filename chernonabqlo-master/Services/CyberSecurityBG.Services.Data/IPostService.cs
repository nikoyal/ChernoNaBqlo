namespace CyberSecurityBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        Task<int> CreateAsync(string title, string content, int categoryId, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetCountByCategoryId(int categoryId);

        Task<bool> IncrementViews(int id);

        public void EditById(int id,  string title, string content);
    }
}
