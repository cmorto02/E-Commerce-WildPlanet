using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IInventoryManager _product;

        public DeleteModel(IInventoryManager product)
        {
            _product = product;
        }
        [FromRoute]
        public int ID { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await _product.DeleteProduct(ID);
            return RedirectToPage("ProductManagement");
        }
    }
}