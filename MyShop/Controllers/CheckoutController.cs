using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBasketManager _context;
        private readonly IInventoryManager _product;
        private readonly ICheckoutManager _checkout;

        public CheckoutController(UserManager<ApplicationUser> userManager, IBasketManager context, IInventoryManager product, ICheckoutManager checkout)
        {
            _userManager = userManager;
            _context = context;
            _product = product;
            _checkout = checkout;
        }
        public async Task<IActionResult> Receipt()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            string userName = _userManager.GetUserName(User);
            Basket basket = await _context.GetBasket(userName);
            basket.TotalPrice = 0;
            foreach (var item in basket.BasketList)
            {
                basket.TotalPrice += item.LineItemAmount;
            }
            Order order = await _checkout.CreateOrder(user, basket.TotalPrice);
            foreach (var item in basket.BasketList)
            {
                await _checkout.CreateOrderItem(order, item);
            }

            order.OrderList = await _checkout.GetOrderItems(order.ID);
            return View(basket);
        }
    }
}
