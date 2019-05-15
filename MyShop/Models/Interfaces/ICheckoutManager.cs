using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Interfaces
{
    public interface ICheckoutManager
    {
        Task<Order> CreateOrder(ApplicationUser user, double totalPrice);
        Task CreateOrderItem(Order order, BasketItems basketitem);
        Task<List<OrderItems>> GetOrderItems(int id);
        Task<Order> GetOrder(int id);
        Task<string> SendRecieptEmail(string email);
    }
}
