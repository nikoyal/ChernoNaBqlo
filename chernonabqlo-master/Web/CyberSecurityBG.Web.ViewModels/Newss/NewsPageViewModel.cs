namespace CyberSecurityBG.Web.ViewModels.Newss
{
    using System.Collections.Generic;

    public class NewsPageViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }

        public string Category { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
