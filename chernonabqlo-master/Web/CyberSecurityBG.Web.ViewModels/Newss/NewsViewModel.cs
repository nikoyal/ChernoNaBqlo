namespace CyberSecurityBG.Web.ViewModels.Newss
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Text.RegularExpressions;

    using CyberSecurityBG.Data.Models;
    using CyberSecurityBG.Services.Mapping;

    public class NewsViewModel : IMapFrom<News>, IMapTo<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PictureUrl { get; set; }


        public IEnumerable<NewsCommentViewModel> NewsComments { get; set; }

        public string ShortContent
        {
            get
            {
                var shcontent = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                //shcontent.Replace("\n", string.Empty).Replace("\r", string.Empty);
                if (shcontent.Length > 75)
                {
                    shcontent = shcontent.Substring(0, 70) + "...";
                }
                else
                {
                    shcontent += Environment.NewLine;
                }

                return shcontent;
            }
        }

        public string ShortTitle
        {
            get
            {
                var Title = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>", string.Empty));
                Title.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return Title.Length > 65
                        ? Title.Substring(0, 65) + "..."
                        : Title;
            }
        }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString =>
            this.CreatedOn.Hour == 0 && this.CreatedOn.Minute == 0
            ? this.CreatedOn.ToString("ddd, dd MMM yyyy", new CultureInfo("bg-BG"))
            : this.CreatedOn.ToString("ddd, dd MMM yyyy HH:mm", new CultureInfo("bg-BG"));

        public int Views { get; set; }
    }
}
