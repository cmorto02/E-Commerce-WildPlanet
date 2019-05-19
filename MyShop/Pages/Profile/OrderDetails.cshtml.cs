using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Models;
using MyShop.Models.Interfaces;

namespace MyShop.Pages.Profile
{
    public class OrderDetailsModel : PageModel
    {
        private readonly ICheckoutManager _checkout;

        public Order order { get; set; }

        [FromRoute]
        public int? ID { get; set; }

        public OrderDetailsModel(ICheckoutManager checkout)
        {
            _checkout = checkout;
        }

        public async Task OnGetAsync()
        {
            order = await _checkout.GetOrder(ID.GetValueOrDefault());
            order.OrderList = await _checkout.GetOrderItems(order.ID);
        }
    }
}