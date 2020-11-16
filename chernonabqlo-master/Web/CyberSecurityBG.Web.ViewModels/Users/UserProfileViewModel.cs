namespace CyberSecurityBG.Web.ViewModels.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class UserProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
