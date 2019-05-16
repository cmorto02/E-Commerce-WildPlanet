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

        public CheckoutService(MyShopDbContext context, IEmailSender emailSender, IBasketManager basket )
        {
            _basket = basket;
            _emailSender = emailSender;
            _context = context;
        }
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

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        public async Task<List<OrderItems>> GetOrderItems(int id)
        {
            var orderItems = await _context.OrderItems.Where(i => i.OrderID == id).ToListAsync();
            return orderItems;
        }
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
