using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Handlers
{
    public class LovesAnimals : IAuthorizationRequirement
    {
        public string laRequirement = "true";
    }

}
