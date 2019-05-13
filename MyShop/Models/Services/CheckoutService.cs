using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Services
{
    public class CheckoutService : ICheckoutManager
    {
        private MyShopDbContext _context;

        public CheckoutService(MyShopDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrder(ApplicationUser user, double grandTotal)
        {
            Order order = new Order
            {
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
    }
}
