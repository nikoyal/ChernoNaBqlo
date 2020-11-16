namespace CyberSecurityBG.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CyberSecurityBG.Common;
    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels.Posts;
    using CyberSecurityBG.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdminPostsController : Controller
    {
        private readonly IPostService postService;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IUserService userService;

        public AdminPostsController(IPostService postService, IDeletableEntityRepository<Post> postRepository, IUserService userService)
        {
            this.postService = postService;
            this.postRepository = postRepository;
            this.userService = userService;
        }


        public async Task<IActionResult> DeleteById(int id)
        {
            var post = this.postRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.postRepository.Delete(post);
            await this.postRepository.SaveChangesAsync();
            return this.RedirectToAction("Topics", "Forum", new { area = string.Empty });
        }

        public IActionResult GetEditById(int id)
        {
            var postViewModel = this.postService.GetById<PostViewModel>(id);
            return this.View(postViewModel);
        }

        public async Task<IActionResult> EditById(int id, string title, string content)
        {
            var post = this.postRepository.All().Where(x => x.Id == id).FirstOrDefault();
            post.Title = title;
            post.Content = content;
            this.postRepository.Update(post);
            await this.postRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", "Posts", new { id = post.Id, area = string.Empty });
        }

        public IActionResult GetAllUsers()
        {
            var viewModel = new AllUsersViewModel();
            var users = this.userService.GetAll<UserProfileViewModel>("");
            viewModel.Users = users;
            return this.View(viewModel);
        }
    }
}
