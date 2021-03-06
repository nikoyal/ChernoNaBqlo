﻿namespace CyberSecurityBG.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNewsCommentInputModel
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(650, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
