using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.data;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ICheckoutManager _checkout;
        public ProfileModel(UserManager<ApplicationUser> userManager, ICheckoutManager checkout)
        {
            _userManager = userManager;
            _checkout = checkout;
        }
        [BindProperty]
        public ApplicationUser User { get; set; }

        [FromRoute]
        public string ID { get; set; }

        public async Task OnGetAsync()
        {
            ApplicationUser User = await _userManager.FindByEmailAsync(ID);
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.FindByEmailAsync(ID);
            user.FirstName = User.FirstName;
            user.LastName = user.LastName;

            Claim nameClaim = new Claim("FullName", $"{user.FirstName} { user.LastName} ");
            await _userManager.AddClaimAsync(user, nameClaim);

            await _userManager.UpdateAsync(user);
            return RedirectToPage("/Profile/Profile", new { id = user.Email });
        }

    }
}