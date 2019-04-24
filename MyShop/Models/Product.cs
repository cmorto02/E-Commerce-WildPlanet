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
        public string Type { get; set; }
        public int Price { get; set; }
        public int Description { get; set; }
        public string ImageStuffedAnimal { get; set; }
        public string ImageAnimal { get; set; }
        public string Summary { get; set; }
        public string AmmountLeft { get; set; }
    }
}
