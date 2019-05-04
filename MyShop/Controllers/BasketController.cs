using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.data;
using MyShop.Models.Interfaces;

namespace MyShop.Controllers
{
    public class BasketController : Controller
    {
        private IBasketManager _context;

        public BasketController(IBasketManager context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var basketITems = await _context.GetAllItems();
                return View(basketITems);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(int productID, string username)
        {
            if (ModelState.IsValid)
            {
            await _context.AddBasketItem(productID, username);
                return RedirectToAction(nameof(Index));
            }
            return View();
            

        }
    }
}