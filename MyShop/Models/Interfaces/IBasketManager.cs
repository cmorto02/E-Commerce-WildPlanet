using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Interfaces
{
    public interface IBasketManager
    {
        Task AddBasketItem(int productID, string username);

        Task<BasketItems> RemoveBasketItem(int basketID);

        Task RemoveBasketItemFR(int basketID);

        Task<IEnumerable<BasketItems>> GetAllItems();

        bool BasketExists(int id);

        Task UpdateBasketItem(int id, BasketItems basketItems);

        Task CreateBasket(Basket basket);

        Task<Basket> GetBasket(string userName);

        Task<BasketItems> GetBasketItem(int id);

    }
}
