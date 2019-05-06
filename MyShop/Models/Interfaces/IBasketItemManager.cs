using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Interfaces
{
    public interface IBasketItemManager
    {
        Task<BasketItems> GetBasketItem(int id);
        Task<IEnumerable<BasketItems>> GetAmenities();
        Task UpdateBasketItem(int id, BasketItems BI);
        bool BasketItemsExists(int id);
    }
}
