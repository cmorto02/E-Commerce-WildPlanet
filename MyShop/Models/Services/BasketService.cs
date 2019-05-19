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

        /// <summary>
        /// will add a product to the basket of the user
        /// </summary>
        /// <param name="productID">allows us to select a product</param>
        /// <param name="username">allows us to pair selected products to an user</param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddBasketItem(int productID, string username)
        {
            try
            {
                Basket basket = await _context.Basket
                                         .FirstOrDefaultAsync(x => x.UserName == username);

                Product product = await _context.Product
                                         .FirstOrDefaultAsync(x => x.ID == productID);

                if (BasketExists(productID, username))
                {
                    BasketItems item = await _context.BasketItems.FirstOrDefaultAsync(x => x.ID == productID);
                    item.Quantity++;
                    item.LineItemAmount += product.Price;
                }
                else
                {
                BasketItems basketItem = new BasketItems()
                {
                    BasketID = basket.ID,
                    ProductID = product.ID,
                    Product = product,
                    Quantity = 1,
                    LineItemAmount = product.Price
                };
                _context.BasketItems.Add(basketItem);
                }
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// used in the edit
        /// </summary>
        /// <param name="id">checks id of basket for user (ensures logged in) </param>
        /// <param name="username">user identification</param>
        /// <returns>bool</returns>
        public bool BasketExists(int id, string username)
        {
            Basket basket = _context.Basket
                                         .FirstOrDefault(x => x.UserName == username);
            return _context.BasketItems.Any(e => e.ID == id && e.BasketID == basket.ID);
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
        /// <summary>
        /// updates a given basket item 
        /// </summary>
        /// <param name="id">selects the item in the basket</param>
        /// <param name="basketItems">updates obj with a newly created obj with updates</param>
        /// <returns>update</returns>
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
        /// <summary>
        /// removes a selected item from the users basket
        /// </summary>
        /// <param name="basketID">the baskrt for the user</param>
        /// <returns>updated basket (removed) </returns>
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

        /// <summary>
        /// create a new basket for an user 
        /// </summary>
        /// <param name="basket">the basket obj on registration</param>
        /// <returns>basket is added to the db</returns>
        public async Task CreateBasket(Basket basket)
        {
            _context.Add(basket);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a basket for a specific user
        /// </summary>
        /// <param name="userName">user identification</param>
        /// <returns>the basket for the user</returns>
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

        /// <summary>
        /// selects a specific item in the basket for an user.
        /// </summary>
        /// <param name="id">basket item identification</param>
        /// <returns>the basket item that was selected</returns>
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
