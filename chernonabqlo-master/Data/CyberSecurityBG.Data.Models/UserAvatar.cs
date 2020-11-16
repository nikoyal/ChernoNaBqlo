using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBG.Data.Models
{
    public class UserAvatar : IdentityUser
    {
        public string Avatar { get; set; }
    }
}
