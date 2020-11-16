using CyberSecurityBG.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBG.Data.Models
{
    public class RSSChannel : BaseDeletableModel<int>
    {
        public string URL { get; set; }

        public string Category { get; set; }
    }
}
