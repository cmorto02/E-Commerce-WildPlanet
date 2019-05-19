using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Pages.Admin
{
    [Authorize(Policy="Admin")]
    public class ProductManagementModel : PageModel
    {
        private readonly IInventoryManager _product;

        public ProductManagementModel(IInventoryManager product)
        {
            _product = product;
        }
        public async void OnPostDelete(int id)
        {
            await _product.DeleteProduct(id);
        }
        public void OnGet()
        {

        }
    }
}