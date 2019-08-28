using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiolia.NetCore21.Web.Models;

namespace Aiolia.NetCore21.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult bootstrap()
        {
            return View();
        }

        
    }
}
