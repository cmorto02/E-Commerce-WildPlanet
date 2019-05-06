using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{
    public class BasketItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}