// Author: Ryan Pinkney
// This is my types view component for the books

using System;
using System.Linq;
using ismission7RyanPinkney.Models;
using Microsoft.AspNetCore.Mvc;

namespace ismission7RyanPinkney.Components
{
    public class TypesViewComponent : ViewComponent
    {


        private iBookstoreRepository repo { get; set; }

        public TypesViewComponent(iBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedType = RouteData?.Values["category"];


            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }








    }
}
