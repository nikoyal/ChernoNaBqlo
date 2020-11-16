namespace CyberSecurityBG.Web.Controllers
{
    using System.Threading.Tasks;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Data;
    using CyberSecurityBG.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class NewsCommentsController : Controller
    {
        private readonly INewsCommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsCommentsController(INewsCommentService commentService, UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateNewsCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.commentService.Create(input.PostId, userId, input.Content);
            return this.RedirectToAction("ById", "News", new { id = input.PostId });
        }
    }
}
