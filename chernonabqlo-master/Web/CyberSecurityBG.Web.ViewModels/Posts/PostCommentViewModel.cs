namespace CyberSecurityBG.Web.ViewModels.Posts
{
    using System;
    using System.Globalization;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;
    using Ganss.XSS;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public string ProfilePicture { get; set; }

        public string CreatedOnAsString =>
        this.CreatedOn.Hour == 0 && this.CreatedOn.Minute == 0
        ? this.CreatedOn.ToString("ddd, dd MMM yyyy", new CultureInfo("bg-BG"))
        : this.CreatedOn.ToString("ddd, dd MMM yyyy HH:mm", new CultureInfo("bg-BG"));
    }
}
