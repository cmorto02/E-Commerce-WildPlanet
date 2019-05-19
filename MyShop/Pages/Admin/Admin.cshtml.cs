using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.data;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Pages.Admin
{
    [Authorize(Policy = "Admin")]
    public class AdminModel : PageModel
    {
        private ApplicationDbContext _context;
        private MyShopDbContext _shopContext;
        private IInventoryManager _product;
        private ICheckoutManager _order;

        public AdminModel(ApplicationDbContext applicationDbContext, MyShopDbContext myShopDbContext, IInventoryManager product, ICheckoutManager order)
        {
            _context = applicationDbContext;
            _shopContext = myShopDbContext;
            _product = product;
            _order = order;
        }
        [FromRoute]
        public string ID { get; set; }      
        public void OnGet()
        {
            var RetrieveUserInfo = _context.Users.Where(x => x.Id == ID);
        }
    }
}