using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    [Authorize(Policy = "LovesAnimals")]
    public class LovesAnimalsController : Controller
    {
        /// <summary>
        /// landing page view
        /// </summary>
        /// <returns>Default view of the exclusive page</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// authorizes access to the view
        /// </summary>
        /// <returns>if successful returns a view</returns>
        [Authorize]
        public IActionResult LovesAnimals()
        {
            return View();
        }
    }
}
