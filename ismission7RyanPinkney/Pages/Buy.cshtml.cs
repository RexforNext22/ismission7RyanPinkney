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


        public BuyModel (iBookstoreRepository temp)
        {
            repo = temp;
        }



        //Instance of the basket
        public Basket Basket { get; set; }

        // For the return url
        public string ReturnUrl { get; set; }


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


    }
}
