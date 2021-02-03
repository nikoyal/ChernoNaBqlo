namespace CyberSecurityBG.Data.Models
{
    using System.Collections.Generic;

    using CyberSecurityBG.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public News()
        {
            this.NewsComments = new HashSet<NewsComment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PictureUrl { get; set; }

        public string Category { get; set; }

        public int Views { get; set; }

        public string Source { get; set; }

        public bool CreatedByAdmin { get; set; }

        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}
