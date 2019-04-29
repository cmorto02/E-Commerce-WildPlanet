using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageStuffedAnimal { get; set; }
        public string ImageAnimal { get; set; }
        public string Summary { get; set; }
        public int AmmountLeft { get; set; }
    }
}
