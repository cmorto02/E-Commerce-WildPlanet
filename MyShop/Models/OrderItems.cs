using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class OrderItems
    {

        /// <summary>
        /// properties for the data table
        /// </summary>
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
    }
}
