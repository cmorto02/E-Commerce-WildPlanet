using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Interfaces
{
    interface IInventory
    {
        void CreateProduct(Product product);

        void GetALLProducts();

        void GetByID(int id);

        void Update(int id);

        void Delete(int id);
    }
}
