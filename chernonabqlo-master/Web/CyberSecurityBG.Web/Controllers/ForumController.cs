namespace CyberSecurityBG.Web.Controllers
{
    using System.Linq;

    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Services.Mapping;
    using CyberSecurityBG.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public ForumController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Topics()
        {
            var viewModel = new ForumViewModel();
            var categories = this.categoriesService.GetAll<ForumCategoryViewModel>();

            viewModel.Categories = categories;
            viewModel.TotalPosts = categories.Sum(x => x.PostsCount);
            return this.View(viewModel);
        }
    }
}
