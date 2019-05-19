using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Models;
using MyShop.Interfaces;
using MyShop.Models.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MyShop.Pages.Admin
{
    public class ProductEditModel : PageModel
    {

        private readonly IInventoryManager _product;

        public ProductEditModel(IInventoryManager product, IConfiguration configuration)
        {
            _product = product;
            BlobImage = new Blob(configuration);
        }
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile ImageStuffedAnimal { get; set; }

        [BindProperty]
        public IFormFile ImageAnimal { get; set; }

        public Blob BlobImage { get; set; }


        public async Task OnGet()
        {
            Product = await _product.GetProduct(ID.GetValueOrDefault())?? new Product();
        }

        public async Task<IActionResult> OnPost()
        {
            var prod = await _product.GetProduct(ID.GetValueOrDefault()) ?? new Product();

            prod.Name = Product.Name;
            prod.Price = Product.Price;
            prod.Description = Product.Description;
            if (ImageStuffedAnimal !=null)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageStuffedAnimal.CopyToAsync(stream);
                }
                var container = await BlobImage.GetContainer("wildplanetimages");
                BlobImage.UploadFile(container, ImageStuffedAnimal.FileName, filePath);
                CloudBlob blob1 = await BlobImage.GetBlob(ImageStuffedAnimal.FileName, container.Name);
                prod.ImageStuffedAnimal = blob1.Uri.ToString();
            }
            if (ImageAnimal != null)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageAnimal.CopyToAsync(stream);
                }
                var container = await BlobImage.GetContainer("wildplanetimages");
                BlobImage.UploadFile(container, ImageAnimal.FileName, filePath);
                CloudBlob blob2 = await BlobImage.GetBlob(ImageAnimal.FileName, container.Name);
                prod.ImageAnimal = blob2.Uri.ToString();
            }
            prod.Summary = Product.Summary;
            prod.AmmountLeft = Product.AmmountLeft;

            await _product.UpdateProduct(prod);

            return RedirectToPage("ProductManagement");
        }
        
        public async Task<IActionResult> OnPostDelete()
        {
            await _product.DeleteProduct(ID.GetValueOrDefault());
            return RedirectToPage("ProductManagement");
        }
    }
}