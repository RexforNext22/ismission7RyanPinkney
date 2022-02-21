// Author Ryan Pinkney
// This is my BooksViewModel
//


using System;
using System.Linq;

namespace ismission7RyanPinkney.Models.ViewModels
{

    public class BooksViewModels
    {

        // Assing the IQueryable 
        public IQueryable<Books> Books { get; set; }

        // Assign the Page info model to the variable
        public PageInfo PageInfo { get; set; }

    }

}
