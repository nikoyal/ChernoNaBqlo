namespace CyberSecurityBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsService
    {
        Task<int> CreateAsync(string title, string content, string url, string category, string datestr, bool createdbyadmin, string source);

        T GetById<T>(int id);

        Task<bool> IncrementViews(int id);

        IEnumerable<T> GetAll<T>(string category, int? take = null, int skip = 0);

        IEnumerable<T> GetTop<T>(int id);
        int GetCountByCategory(string category);
    }

}

//@foreach(var news in Model.TopNews)
//{
//                                            < article style = "width:350px" >
 
//                                                 < a class="d-flex mr-3" href="fixme">
//                                                    <img style = "width:75px;height:75px" src="@news.PictureUrl" title="@news.Title" alt="----">
//                                                </a>
//                                                <h3 class="h6" style="width:230px">
//                                                    <a class="u-link-v5 g-color-black g-color-primary--hover" href="fix">@news.Title</a>
//                                                    <small>
//                                                        <time datetime = "@news.CreatedOn" ></ time >
//                                                    </ small >
//                                                </ h3 >
//                                            </ article >
//                                        }