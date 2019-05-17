using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Models;
using MyShop.Models.Interfaces;
using MyShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Component
{
    public class BasketComponent : ViewComponent
    {
        private MyShopDbContext _context;
        private IBasketComponentManager _basket;

        /// <summary>
        /// brings in contexts
        /// </summary>
        /// <param name="context">context for application db</param>
        /// <param name="basket">context for basket db</param>
        public BasketComponent(MyShopDbContext context, IBasketComponentManager basket)
        {
            _context = context;
            _basket = basket;
        }
        /// <summary>
        /// Runs the component for the user
        /// </summary>
        /// <returns> renders a view for users to see basket items</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.Name;
            if (userName == null)
            {
                return View();
            }

            var userBasket = await _basket.GetBasket(userName);
            var items = _context.BasketItems.OrderByDescending(x => x.ID);
            var componentItems = items.Where(i => i.BasketID == userBasket.ID);
            List<ComponentViewModel> componentList = new List<ComponentViewModel>();

            foreach (var item in componentItems)
            {
                Product product = await _context.Product.FirstOrDefaultAsync(x => x.ID == item.ProductID);
                ComponentViewModel componentViewModel = new ComponentViewModel();
                componentViewModel.Name = product.Name;
                componentViewModel.Price = product.Price;
                componentList.Add(componentViewModel);
            }
            return View(componentList);
        }
    }
}
