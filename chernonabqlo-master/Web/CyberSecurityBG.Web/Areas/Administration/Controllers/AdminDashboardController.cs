using CyberSecurityBG.Services.Data;
using CyberSecurityBG.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberSecurityBG.Web.Areas.Administration.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IUserService userService;

        public AdminDashboardController(IUserService userService)
        {
            this.userService = userService;
        }

    }
}
