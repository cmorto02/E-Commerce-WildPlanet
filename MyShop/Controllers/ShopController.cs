using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Interfaces;

namespace MyShop.Controllers
{
    public class ShopController : Controller
    {
        private IInventoryManager _context;

        public ShopController(IInventoryManager context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Inventory = await _context.GetALLProducts();
         


            return View(Inventory);
        }
    }
}