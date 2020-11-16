namespace CyberSecurityBG.Web.Controllers
{
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public PostsController(IPostService postService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.postService = postService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<IActionResult> ById(int id)
        {
            var viewModel = this.postService.GetById<PostViewModel>(id);
            await this.postService.IncrementViews(id);
            viewModel.ProfilePicture = this.userService.GetProfilePicture(viewModel.UserUserName);
            foreach (var comment in viewModel.Comments)
            {
                comment.ProfilePicture = this.userService.GetProfilePicture(comment.UserUserName);
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);

            return this.RedirectToAction("ById", new { id = postId });
        }
    }
}
