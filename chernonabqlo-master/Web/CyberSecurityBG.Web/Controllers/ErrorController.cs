using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CyberSecurityBG.Web.Controllers;

namespace CyberSecurityBG.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            return this.RedirectToAction("Index", "Home");
        }
    }
}