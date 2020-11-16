namespace CyberSecurityBG.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class ForumViewModel
    {
        public int TotalPosts { get; set; }

        public IEnumerable<ForumCategoryViewModel> Categories { get; set; }
    }
}
