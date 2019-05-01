using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// properties for each user 
        /// </summary>
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string LoveAnimals { get; set; } = "false";
    }
}
