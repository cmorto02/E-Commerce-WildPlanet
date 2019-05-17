using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Required]
        [Display(Name = "CreditCard")]
        public int CreditCard { get; set; }

    }
}
