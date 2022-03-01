using System;
using ismission7RyanPinkney.Models;
using Microsoft.AspNetCore.Mvc;

namespace ismission7RyanPinkney.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket cartService)
        {
            basket = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
