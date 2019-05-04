using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.data;
using MyShop.Models;
using MyShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyShop.Controllers
{

    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private MyShopDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MyShopDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /// <summary>
        /// returns the view of register
        /// </summary>
        /// <returns>default view</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// takes in register view model and grabs claims from registration
        /// </summary>
        /// <param name="rvm">Register view model</param>
        /// <returns>returns to a new view if succesful will go home if not successful then it will refresh and return the rvm</returns>
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
                    Birthday = rvm.Birthday,
                    LoveAnimals = rvm.LoveAnimals
                };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "I'm sorry, something went wrong. Please try again.");
                }


                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("FullName", $"{user.FirstName} { user.LastName} ");

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim dateOfBirthClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);

                    Claim loveAnimalsClaim = new Claim("LovesAnimals", user.LoveAnimals);

                    List<Claim> claims = new List<Claim> { nameClaim, emailClaim, dateOfBirthClaim, loveAnimalsClaim};
                    await _userManager.AddClaimsAsync(user, claims);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");

                }
             
                Basket basket = new Basket(user.UserName);
                _context.Basket.Add(basket);
               await  _context.SaveChangesAsync();
                
            }
            return View(rvm);

        }
        /// <summary>
        /// Default view for login
        /// </summary>
        /// <returns>default view for login</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// sign's in the user using the information given through the form
        /// </summary>
        /// <param name="lvm">login view model logic and form</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(lvm);
            {

            }
        }
    }
}
