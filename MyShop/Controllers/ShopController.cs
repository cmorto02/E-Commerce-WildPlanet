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
        /// <summary>
        /// bring in context
        /// </summary>
        /// <param name="context">database</param>
        public ShopController(IInventoryManager context)
        {
            _context = context;
        }
        /// <summary>
        /// the home page of shop renders all of the shop items
        /// </summary>
        /// <returns>all products in the database</returns>
        public async Task<IActionResult> Index()
        {
            var Inventory = await _context.GetALLProducts();
         


            return View(Inventory);
        }
    }
}