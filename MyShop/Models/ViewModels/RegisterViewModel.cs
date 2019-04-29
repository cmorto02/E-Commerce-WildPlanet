using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.ViewModels
{

    public class RegisterViewModel
    {
        /*  public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday */
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Do you love animals?")]
        public bool LoveAnimals { get; set; }

    }
}

