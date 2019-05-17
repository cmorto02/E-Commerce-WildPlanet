using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models.Services
{
    public class CheckoutService : ICheckoutManager
    {
        private IBasketManager _basket;
        private IEmailSender _emailSender;
        private MyShopDbContext _context;

        /// <summary>
        /// brings in contexts
        /// </summary>
        /// <param name="context">the shop db context</param>
        /// <param name="emailSender">the email sender context</param>
        /// <param name="basket">the basket context</param>
        public CheckoutService(MyShopDbContext context, IEmailSender emailSender, IBasketManager basket )
        {
            _basket = basket;
            _emailSender = emailSender;
            _context = context;
        }
        /// <summary>
        /// this will create a new order for the user
        /// </summary>
        /// <param name="user">user that is creating the order</param>
        /// <param name="grandTotal">the total price</param>
        /// <returns>the order obj</returns>
        public async Task<Order> CreateOrder(ApplicationUser user, double grandTotal)
        {
            Order order = new Order
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserID = user.Id,
                GrandTotal = grandTotal,
                OrderDate = DateTime.Today
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
        /// <summary>
        /// will ceate an order item
        /// </summary>
        /// <param name="order">will add items to a given order</param>
        /// <param name="basketitem">will add the information for this basket item to the order items</param>
        /// <returns>context update</returns>
        public async Task CreateOrderItem(Order order, BasketItems basketitem)
        {
            OrderItems orderItem = new OrderItems
            {
                ProductID = basketitem.ProductID,
                OrderID = order.ID,
                Quantity = basketitem.Quantity,
            };
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// will retrieve a given order
        /// </summary>
        /// <param name="id">identification for specific order</param>
        /// <returns>order obj</returns>
        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        /// <summary>
        /// will retrieve an orders items
        /// </summary>
        /// <param name="id">identification for which item to retrieve from order</param>
        /// <returns>orderItem obj </returns>
        public async Task<List<OrderItems>> GetOrderItems(int id)
        {
            var orderItems = await _context.OrderItems.Where(i => i.OrderID == id).ToListAsync();
            return orderItems;
        }

       /// <summary>
       /// sends an email to the user with information from their transaction on the order page
       /// </summary>
       /// <param name="email">identification for the user </param>
       /// <returns>thank you message and email to given email address</returns>
        public async Task<string> SendRecieptEmail(string email)
        {
            if (_context.Basket != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<h1>Thank you for your purchase!</h1>");
                sb.AppendLine("The items you have purchased are: <ul>");
                var collection = _basket.GetAllItems();

                foreach (var value in collection)
                {
                    sb.Append($"<li>Product: {value.Product.Name} Price: {value.Product.Price}</li>");

                }
                sb.Append("</ul>");
                sb.AppendLine("<h3>Thank you for your purchase!</h3>");
                var recieptEmail = sb.ToString();

                await _emailSender.SendEmailAsync(email, "Completed Purchase", recieptEmail);

                return "Success";

            }
            return "Fail";
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChangesAsync();
        }
    }
}
