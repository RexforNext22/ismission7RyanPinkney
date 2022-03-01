using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ismission7RyanPinkney.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ismission7RyanPinkney.Controllers
{
    public class PurchaseController : Controller
    {

        // Bring in the repo and basket
        private iPurchaseRepository repo { get; set; }

        private Basket basket { get; set; }

        public PurchaseController(iPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;

        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }


        // Post route for the purchase
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {

            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty");
            }

            if (ModelState.IsValid)
            {

                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");


            }
            else
            {
                return View();
            }

        }
    }
}
