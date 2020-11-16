namespace CyberSecurityBG.Web.Controllers
{
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Common.Repositories;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> UserProfile()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            if (user == null)
            {
                return this.RedirectToAction("Error");
            }

            // var viewModel = this.usersService.GetUser<UserProfilViewModel>(user.UserName);
            // return this.View(viewModel);
            var model = new UserProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                CreatedOn = user.CreatedOn,
            };

            return this.View(model);
        }

        public async Task<IActionResult> EditProfile(string username, string imageurl)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            if (user == null)
            {
                return this.RedirectToAction("Error");
            }

            if (username.Length <= 20 && username.Length >= 3)
            {
                user.UserName = username;
            }

            user.ImageUrl = imageurl;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
            return this.RedirectToAction("UserProfile");
        }
    }
}
