namespace CyberSecurityBG.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostCreateInputModel
    {
        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }

        [MaxLength(800)]
        [MinLength(20)]
        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
