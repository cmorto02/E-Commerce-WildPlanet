using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MyShop.data;
using MyShop.Models;
using MyShop.Models.Interfaces;
using MyShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Controllers
{

    public class AccountController : Controller
    {
        private readonly IBasketManager _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IBasketManager context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailSender = emailSender;
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

                    //give the user a role.
                    if (rvm.Email.ToLower() == "amanda@codefellows.com")
                    {

                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

              



                    await _emailSender.SendEmailAsync(rvm.Email, "Thank you for registering", "<p> Hello Welcome </p>");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    Basket basket = new Basket()
                    {
                        TotalItems = 0,
                        TotalPrice = 0,
                        UserName = user.UserName,
                        BasketList = null
                    };
                    await _context.CreateBasket(basket);

                    return RedirectToAction("Index", "Home");

                }             
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
        }

        /// <summary>
        /// Logs the user out of our website
        /// </summary>
        /// <returns>Redirect to the home page</returns>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
