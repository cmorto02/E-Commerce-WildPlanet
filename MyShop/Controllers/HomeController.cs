using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// home page
        /// </summary>
        /// <returns>default landing home page view</returns>
        public IActionResult Home()
        {
            return View("Index");
        }

        public IActionResult Index()
        {
            return View("Splash");
        }
    }
}
