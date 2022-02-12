// Author Ryan Pinkney
// This is my ef files that interacts with the repo


using System;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
 
        public class efBookstoreRepository : iBookstoreRepository
        {
            // Set the context
            private BookstoreContext DbContext { get; set; }

            // Context configuration
            public efBookstoreRepository(BookstoreContext temp)
            {
                DbContext = temp;
            }


            public IQueryable<Books> Books => DbContext.Books;

        }
    
}
