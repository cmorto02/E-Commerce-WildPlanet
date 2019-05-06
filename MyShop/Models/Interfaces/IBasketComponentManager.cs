using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Interfaces
{
    public interface IBasketComponentManager
    {
        Task<Basket> GetBasket(string userName);
    }
}
