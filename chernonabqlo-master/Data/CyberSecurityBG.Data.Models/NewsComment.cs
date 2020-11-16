namespace CyberSecurityBG.Data.Models
{
    using CyberSecurityBG.Data.Common.Models;

    public class NewsComment : BaseDeletableModel<int>
    {
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
