using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.data;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Controllers
{
    public class BasketController : Controller
    {
        private IBasketManager _context;
        private IInventoryManager _productContext;
        private UserManager<ApplicationUser> _userManager;



        public BasketController(IBasketManager context, UserManager<ApplicationUser> userManager, IInventoryManager productContext)
        {
            _context = context;
            _userManager = userManager;
            _productContext = productContext;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = _userManager.GetUserName(User);
                var basket = await _context.GetBasket(user);
                return View(basket);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
        public async Task<IActionResult> Create(int productID)
        {
            if (ModelState.IsValid)
            {
                var userName = _userManager.GetUserName(User);
            await _context.AddBasketItem(productID, userName);
                return RedirectToAction(nameof(Index));
            }
            return View();
            

        }

        public async Task<IActionResult> DeleteBasketItem(int id)
        {
            await _context.RemoveBasketItemFR(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int quantity)
        {
            var basketItem = await _context.GetBasketItem(id);

            basketItem.Quantity = quantity;

            int amount = basketItem.Quantity;

            var product = await _productContext.GetProduct(basketItem.ProductID);

            var price = product.Price;

            basketItem.LineItemAmount = price * amount;

            await _context.UpdateBasketItem(id, basketItem);

            return RedirectToAction("Index");
        }
    }
}