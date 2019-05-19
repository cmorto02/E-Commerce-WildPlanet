using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Interfaces;
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
        private MyShopDbContext _shop;
        private IInventoryManager _product;

        public CheckoutService(MyShopDbContext context, IEmailSender emailSender, IBasketManager basket, IInventoryManager product)
        {
            _basket = basket;
            _emailSender = emailSender;
            _shop = context;
            _product = product;
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
            await _shop.Orders.AddAsync(order);
            await _shop.SaveChangesAsync();
            return order;
        }

        public async Task CreateOrderItem(Order order, BasketItems basketitem)
        {
            Product product =await _product.GetProduct(basketitem.ProductID);
            OrderItems orderItem = new OrderItems
            {
                ProductID = basketitem.ProductID,
                OrderID = order.ID,
                Quantity = basketitem.Quantity,
                Name = product.Name,
                Price = product.Price
            };
            await _shop.OrderItems.AddAsync(orderItem);
            await _shop.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _shop.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetLastTenOrders()
        {
            var orders = await GetAllOrders();
            var tenOrders = orders.OrderByDescending(i => i.ID).Take(10).ToList();
            return tenOrders;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _shop.Orders.FindAsync(id);
            return order;
        }

        public async Task<List<OrderItems>> GetOrderItems(int id)
        {
            var orderItems = await _shop.OrderItems.Where(i => i.OrderID == id).ToListAsync();
            return orderItems;
        }

        public Task<List<Order>> GetUserOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendRecieptEmail(string email)
        {
            if (_shop.Basket != null)
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

        public async Task<string> UpdateOrder(Order order)
        {
            _shop.Orders.Update(order);
            await _shop.SaveChangesAsync();

            return "updated";
        }
    }
}
