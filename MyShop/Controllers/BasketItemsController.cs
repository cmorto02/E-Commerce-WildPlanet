using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Controllers
{
    public class BasketItemsController : Controller
    {
        private IBasketItemManager _context;

        public BasketItemsController(IBasketItemManager context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: BasketItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var basketItem = await _context.GetBasketItem(id);
            if (basketItem == null)
            {
                return NotFound();
            }
            return View(basketItem);
        }
    }
}