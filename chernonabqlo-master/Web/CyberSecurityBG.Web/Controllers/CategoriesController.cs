namespace CyberSecurityBG.Web.Controllers
{
    using System;

    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 8;
        private readonly ICategoriesService categoriesService;
        private readonly IPostService postService;
        private readonly IUserService userService;

        public CategoriesController(ICategoriesService categoriesService, IPostService postService, IUserService userService)
        {
            this.categoriesService = categoriesService;
            this.postService = postService;
            this.userService = userService;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            viewModel.ForumPosts = this.postService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);
            var count = this.postService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            viewModel.CurrentPage = page;
            foreach (var post in viewModel.ForumPosts)
            {
                post.UserPicture = this.userService.GetProfilePicture(post.UserUserName);
            }

            return this.View(viewModel);
        }
    }
}
