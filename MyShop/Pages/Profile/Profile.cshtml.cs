using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.data;
using MyShop.Models;

namespace MyShop.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;

        public ProfileModel(SignInManager<ApplicationUser> SignInManager, ApplicationDbContext context)
        {
            _signInManager = SignInManager;
            _context = context;
        }
        public void OnGet(string username)
        {
           
            
            

        }
    }
}