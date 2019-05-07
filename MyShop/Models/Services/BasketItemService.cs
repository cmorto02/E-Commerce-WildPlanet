using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Services
{
    public class BasketItemService : IBasketItemManager
    {
        private MyShopDbContext _context;

        public BasketItemService(MyShopDbContext context)
        {
            _context = context;
        }
        public async Task<BasketItems> GetBasketItem(int id)
        {
            try
            {
                var basketItem = await _context.BasketItems.FindAsync(id);
                if (basketItem == null)
                {
                    return null;
                }

                return basketItem;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<IEnumerable<BasketItems>> GetBasketItems()
        {
            try
            {

                return await _context.BasketItems.ToListAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return null;
            }
        }
        public async Task UpdateBasketItem(int id, [Bind("ID,Name,Quantity,Price")]BasketItems BI)
        {
            try
            {
                _context.Update(BI) ;
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        public bool BasketItemsExists(int id)
        {
            return _context.BasketItems.Any(e => e.ID == id);
        }
    }
}
