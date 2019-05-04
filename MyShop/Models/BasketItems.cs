using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class BasketItems
    {
        public BasketItems(int productID, )
        {

        }
        public int ID { get; set; }
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double LineItemAmount { get; set; }
    }
}
