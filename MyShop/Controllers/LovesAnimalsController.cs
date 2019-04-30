using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    [Authorize(Policy = "LovesAnimalsPolicy")]
    public class LovesAnimalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult LovesAnimals()
        {
            return View();
        }
    }
}
