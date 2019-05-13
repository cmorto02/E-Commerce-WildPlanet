using MyShop.data;
using MyShop.Models.Interfaces;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyShop.Models.Services
{
    public class BasketService : IBasketManager

    {
        private MyShopDbContext _context;
        private ApplicationDbContext _appcontext;
        private IEmailSender _emailSender;

        public BasketService(MyShopDbContext context, ApplicationDbContext appcontext, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _context = context;
            _appcontext = appcontext;
        }
        [HttpPost]
        public async Task AddBasketItem(int productID, string username)
        {
            try
            {
                Basket basket = await _context.Basket
                                         .FirstOrDefaultAsync(x => x.UserName == username);

                Product product = await _context.Product
                                         .FirstOrDefaultAsync(x => x.ID == productID);

                BasketItems basketItem = new BasketItems()
                {
                    BasketID = basket.ID,
                    ProductID = product.ID,
                    Product = product,
                    Quantity = 1,
                    LineItemAmount = product.Price
                };
                _context.BasketItems.Add(basketItem);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool BasketExists(int id)
        {
            try
            {
                return _context.BasketItems.Any(e => e.ID == id);

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return false;
            }
        }

        public  IEnumerable<BasketItems> GetAllItems()
        {
            try
            {

                return  _context.BasketItems.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task UpdateBasketItem(int id, [Bind("ID,BasketID,ProductID,Product,Quantity,LineItemAmount")]BasketItems basketItems)
        { 
            try
            {
                _context.Update(basketItems);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);

            }
        }

        public async Task<BasketItems> RemoveBasketItem(int basketID)
        {
            try
            {
                BasketItems basketitem = await _context.BasketItems
                                            .FirstOrDefaultAsync(x => x.ID == basketID);
                return basketitem;
        
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task RemoveBasketItemFR(int basketID)
        {
            try
            {
                var item = await _context.BasketItems.FindAsync(basketID);
                _context.BasketItems.Remove(item);
                await _context.SaveChangesAsync();

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task CreateBasket(Basket basket)
        {
            _context.Add(basket);
            await _context.SaveChangesAsync();
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

    }
}
