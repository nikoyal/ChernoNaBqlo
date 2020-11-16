namespace CyberSecurityBG.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }


        public IEnumerable<PostInCategoryViewModel> ForumPosts { get; set; }
    }
}
