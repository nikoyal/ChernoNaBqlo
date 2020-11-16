namespace CyberSecurityBG.Web.ViewModels.Categories
{
    using System;

    using AutoMapper;
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post> , IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get;set; }

        public string Title { get; set; }

        public int Views { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

        public string UserPicture { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, PostInCategoryViewModel>().ForMember(x => x.UserPicture, options =>
            {
                options.MapFrom(p => p.ImageUrl);
            });
        }
    }
}