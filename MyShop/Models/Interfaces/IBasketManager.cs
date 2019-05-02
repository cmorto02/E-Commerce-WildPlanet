using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Interfaces
{
    public interface IBasketManager
    {
        Task AddBasketItem(int BasketID, BasketItems basketItem);
        Task<BasketItems> RemoveBasketItem(int basketID);
        Task RemoveBasketItemFR(int basketID);
        Task<IEnumerable<BasketItems>> GetAllItems();
    }
}
