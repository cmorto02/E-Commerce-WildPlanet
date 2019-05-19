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

        public async Task OnPostDelete(int id)
        {
            await _product.DeleteProduct(id);
        }

        public async Task OnPostCreateNewProduct(string name, double price, string description, string imageStuffed, string image, string summary, int amountInStock )
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Description = description,
                ImageStuffedAnimal = imageStuffed,
                ImageAnimal = image,
                Summary = summary,
                AmmountLeft = amountInStock
            };

            await _product.NewProduct(product);
        }
        public async Task OnPostUpdateProduct(int id, string name, double price, string description, string imageStuffed, string image, string summary, int amountInStock)
        {
            var product = await _product.GetProduct(id);

            product.Name = name;
            product.Price = price;
            product.Description = description;
            product.ImageStuffedAnimal = imageStuffed;
            product.ImageAnimal = image;
            product.Summary = summary;
            product.AmmountLeft = amountInStock;

            await _product.UpdateProduct(product);
        }
    }
}