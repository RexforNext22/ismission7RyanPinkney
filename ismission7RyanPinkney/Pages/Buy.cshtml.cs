// Author Ryan Pinkney
// This is my model/controller for the buy razor page


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ismission7RyanPinkney.Infrastructure;
using ismission7RyanPinkney.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ismission7RyanPinkney.Pages
{
    public class BuyModel : PageModel
    {

        // Bring in an instance of the repository
        private iBookstoreRepository repo { get; set; }


        //Instance of the basket
        public Basket Basket { get; set; }

        // For the return url
        public string ReturnUrl { get; set; }



        public BuyModel (iBookstoreRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }


        // Get method for the pages
        public void OnGet(string returnUrl)
        {

            ReturnUrl = returnUrl ?? "/";

            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();

        }


        // For the post method
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Books p = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            Basket.AddItem(p, 1);

            HttpContext.Session.SetJson("Basket", Basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        // For the post method
        public IActionResult OnPostRemove(int bookid, string returnUrl)
        {

            Basket.RemoveItem(Basket.Items.First(x => x.Books.BookId == bookid).Books);


            return RedirectToPage(new { ReturnUrl = returnUrl });

        }


    }
}
