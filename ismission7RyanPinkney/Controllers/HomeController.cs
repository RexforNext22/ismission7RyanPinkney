// Author Ryan Pinkney
// This is my home controller



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ismission7RyanPinkney.Models;
using static ismission7RyanPinkney.Models.iBookstoreRepository;
using ismission7RyanPinkney.Models.ViewModels;

namespace ismission7RyanPinkney.Controllers
{
    public class HomeController : Controller
    {

        // Repo configuration
        private iBookstoreRepository repo;

        public HomeController(iBookstoreRepository temp)
        {
            repo = temp;
        }


        // This is the Get route for the index
        [HttpGet]
        public IActionResult Index() => View();


        // This is the Get route for the List
        [HttpGet]
        public IActionResult List(int iPageNum = 1)
        {
            // Set the number of results
            int iPageSize = 10;

            
            var x = new BooksViewModels
            {
                Books = repo.Books
                .Skip(iPageSize * (iPageNum - 1))
                .Take(iPageSize),

                PageInfo = new PageInfo
                {
                    iTotalBooksNum = repo.Books.Count(),
                    iBooksPerPage = iPageSize,
                    iCurrentPage = iPageNum
                }

            };

  

            return View(x);
        }












        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
