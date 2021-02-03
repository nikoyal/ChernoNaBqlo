using CyberSecurityBG.Data.Models;
using CyberSecurityBG.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CyberSecurityBG.Web.ViewModels.Newss
{
    public class TopNewsViewModel : IMapFrom<News>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }

        public string CreatedOnAsString =>
    this.CreatedOn.Hour == 0 && this.CreatedOn.Minute == 0
    ? this.CreatedOn.ToString("ddd, dd MMM yyyy", new CultureInfo("bg-BG"))
    : this.CreatedOn.ToString("ddd, dd MMM yyyy HH:mm", new CultureInfo("bg-BG"));

        public string ShortTitle
        {
            get
            {
                var Title = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>", string.Empty));
                Title.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return Title.Length > 60
                        ? Title.Substring(0, 60) + "..."
                        : Title;
            }
        }
    }
}
