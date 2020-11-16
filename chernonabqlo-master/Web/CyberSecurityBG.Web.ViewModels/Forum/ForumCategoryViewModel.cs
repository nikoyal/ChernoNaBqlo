namespace CyberSecurityBG.Web.ViewModels.Forum
{

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class ForumCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/Forum/{this.Name.Replace(' ', '-')}";
    }
}
