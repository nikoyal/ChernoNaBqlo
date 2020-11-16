namespace CyberSecurityBG.Web.ViewModels.Posts
{
    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}