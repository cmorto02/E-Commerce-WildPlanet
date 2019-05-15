using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.data;

namespace MyShop.Pages.Admin
{
    [Authorize(Policy = "Admin")]
    public class AdminModel : PageModel
    {
        private ApplicationDbContext _context;
        private MyShopDbContext _shopContext;

        public AdminModel(ApplicationDbContext applicationDbContext, MyShopDbContext myShopDbContext)
        {
            _context = applicationDbContext;
            _shopContext = myShopDbContext;
        }
        [FromRoute]
        public string ID { get; set; }

        
       
        public void OnGet()
        {
            var RetrieveUserInfo = _context.Users.Where(x => x.Id == ID);
        }


        ///
        ///Retrieve orders data and render the last 10 completed orders
        ///
    }
}