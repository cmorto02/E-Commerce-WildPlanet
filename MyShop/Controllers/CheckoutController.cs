using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Configuration;

        public CheckoutController(UserManager<ApplicationUser> userManager, IBasketManager context, IInventoryManager product, ICheckoutManager checkout, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _product = product;
            _checkout = checkout;
            Configuration = configuration;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Receipt(string address, string city, string zip)
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
            order.Address = address;
            order.City = city;
            order.Zip = zip;
            _checkout.UpdateOrder(order);
            foreach (var item in basket.BasketList)
            {
                await _checkout.CreateOrderItem(order, item);
            }
            order.OrderList = await _checkout.GetOrderItems(order.ID);

            Payment payment = new Payment(Configuration, _context);
            order.Completed = payment.Run(order);
            _checkout.UpdateOrder(order);
            if (order.Completed == true)
            {
                await _checkout.SendRecieptEmail(user.Email);
            }
            return View(basket);

        }
    }
}
