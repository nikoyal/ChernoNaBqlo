namespace CyberSecurityBG.Web.ViewModels.Newss
{
    using System.ComponentModel.DataAnnotations;

    public class NewsCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MinLength(20)]
        public string Url { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
