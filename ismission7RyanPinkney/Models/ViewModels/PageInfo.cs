using System;
namespace ismission7RyanPinkney.Models.ViewModels
{

    public class PageInfo
    {
        // Keep track of how many books there are in total
        public int iTotalBooksNum { get; set; }

        // Store the books per page
        public int iBooksPerPage { get; set; }

        // Store the current page
        public int iCurrentPage { get; set; }

        // Figure out how many pages we need
        public int iTotalPages => (int) Math.Ceiling((double) iTotalBooksNum / iBooksPerPage); // This is how we cast

    }
}
