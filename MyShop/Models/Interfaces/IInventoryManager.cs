﻿using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Interfaces
{
    public interface IInventoryManager
    {
        void CreateProduct(Product product);

        Task<List<Product>> GetALLProducts();

    }
}
