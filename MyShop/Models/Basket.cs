using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Basket
    {
        /// <summary>
        /// properties for the basket table
        /// </summary>
        public int ID { get; set; }
        public int TotalItems { get; set; }
        public double TotalPrice { get; set; }
        public string UserName { get; set; }
        public List<BasketItems> BasketList { get; set; }
    }
}
