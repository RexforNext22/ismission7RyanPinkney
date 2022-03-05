// Author Ryan Pinkney
// This is my ef files that interacts with the repo


using System;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
 
        public class efBookstoreRepository : iBookstoreRepository
        {
            // Set the context
            private BookstoreContext context { get; set; }

            // Context configuration
            public efBookstoreRepository(BookstoreContext temp)
            {
            context = temp;
            }


            public IQueryable<Books> Books => context.Books;



        // For the admin interface
        public void SaveBook(Books b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Books b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Books b)
        {
            context.Remove(b);
            context.SaveChanges();
        }





    }

}
