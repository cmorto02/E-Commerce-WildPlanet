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

        /// <summary>
        /// Bring in contexts
        /// </summary>
        /// <param name="userManager">usr manager context</param>
        /// <param name="context">applicationuser db context for users</param>
        /// <param name="product">product db context for product information</param>
        /// <param name="checkout">brings in the checkout context and methods</param>
        /// <param name="configuration">brings in user secret data</param>
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

        /// <summary>
        /// This method will create the order object and then send a reciept as a view
        /// </summary>
        /// <param name="address">the users address</param>
        /// <param name="city">the users city</param>
        /// <param name="zip">the users zip</param>
        /// <returns>a reciept view </returns>
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
            await _checkout.UpdateOrder(order);
            foreach (var item in basket.BasketList)
            {
                await _checkout.CreateOrderItem(order, item);
            }
            order.OrderList = await _checkout.GetOrderItems(order.ID);

            Payment payment = new Payment(Configuration, _context);
            order.Completed = payment.Run(order);
            await _checkout.UpdateOrder(order);
            if (order.Completed == true)
            {
                await _checkout.SendRecieptEmail(user.Email);
            }
            return View(basket);

        }
    }
}
