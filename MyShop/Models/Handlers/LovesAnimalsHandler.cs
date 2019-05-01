using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyShop.Models.Handlers
{
    public class LovesAnimalsHandler : AuthorizationHandler<LovesAnimals>
    {
        /// <summary>
        /// check to see that the signed in user has the required claim to access the page
        /// </summary>
        /// <param name="context">database</param>
        /// <param name="requirement">the requirement we look for in the claim</param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LovesAnimals requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "LovesAnimals"))
            {
                return Task.CompletedTask;
            }

            var lovesAnimals = context.User.FindFirst(c => c.Type == "LovesAnimals").Value;

            if (lovesAnimals == requirement.laRequirement)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
