using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{

        public class AccountController : Controller
        {
            private UserManager<ApplicationUser> _userManager;
            private SignInManager<ApplicationUser> _signInManager;


            public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel rvm)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        Email = rvm.Email,
                        UserName = rvm.Email,
                        FirstName = rvm.FirstName,
                        LastName = rvm.LastName,
                        Birthday = rvm.Birthday
                    };
                    var result = await _userManager.CreateAsync(user, rvm.Password);
                    RedirectToAction("Index", "Home");
                }
                return View(rvm);
            }
        }
}
