using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Basket
    {
        public Basket(int userID)
        {
            UserID = userID.ToString();
        }
        public int ID { get; set; }
        public int TotalItems { get; set; }
        public double TotalPrice { get; set; }
        public string UserID { get; set; }
        public List<BasketItems> BasketList { get; set; }
    }
}
