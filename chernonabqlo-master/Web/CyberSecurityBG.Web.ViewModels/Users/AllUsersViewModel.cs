using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBG.Web.ViewModels.Users
{
    public class AllUsersViewModel
    {
        public IEnumerable<UserProfileViewModel> Users { get; set; }
    }
}
