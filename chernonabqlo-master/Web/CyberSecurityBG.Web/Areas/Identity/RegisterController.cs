using CyberSecurityBG.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberSecurityBG.Web.Areas.Identity
{
    public class RegisterController : BaseController
    {
        public IActionResult Register()
        {
            return this.View("~/Views/Home/Index.cshtml");
        }
    }
}
