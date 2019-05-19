using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ICheckoutManager _checkout;
        public IndexModel(UserManager<ApplicationUser> userManager, ICheckoutManager checkout)
        {
            _userManager = userManager;
            _checkout = checkout;
        }
        [BindProperty]
        public ApplicationUser User { get; set; }

        [BindProperty]
        public string password { get; set; }

        [FromRoute]
        public string ID { get; set; }

        public async Task OnGetAsync()
        {
            ApplicationUser User = await _userManager.FindByEmailAsync(ID);
        }

     
        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.FindByEmailAsync(ID);
            ///generates token for the password reset to be sent in email to verify that the owner of the profile has requested to reset password
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            string nospaces = code.Replace(" ", "+");
            IdentityResult result = await _userManager.ResetPasswordAsync(user, nospaces, password);

            if (_userManager.SupportsUserSecurityStamp)
            {
                await _userManager.UpdateSecurityStampAsync(user);
            }

            await _userManager.UpdateAsync(User);
            return RedirectToPage("/Profile/Profile", new { id = user.Email });

        }
    }
}