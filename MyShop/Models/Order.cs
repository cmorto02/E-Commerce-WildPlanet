using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Order
    {

        /// <summary>
        /// properties for the order table
        /// </summary>
        public int ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public bool Completed { get; set; }
        public List<OrderItems> OrderList { get; set; }
        public double GrandTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
