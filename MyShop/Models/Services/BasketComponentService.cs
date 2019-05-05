using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Services
{
    public class BasketComponentService : IBasketComponentManager
    {
        private MyShopDbContext _context;
        private ApplicationDbContext _appcontext;

        public BasketComponentService(MyShopDbContext context, ApplicationDbContext appcontext)
        {
            _context = context;
            _appcontext = appcontext;
        }
        public async Task<Basket> GetBasket(string userName)
        {
            var basket = _context.Basket.FirstOrDefault(x => x.UserName == userName);
            basket.BasketList = await _context.BasketItems.Where(b => b.BasketID == basket.ID).ToListAsync();
            foreach (var item in basket.BasketList)
            {
                item.Product = await _context.Product.FirstOrDefaultAsync(e => e.ID == item.ProductID);
            }
            return basket;
        }
    }
}
