using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ismission7RyanPinkney.Models.ViewModels
{
    public class efPurchaseRepository : iPurchaseRepository
    {

        private BookstoreContext context;

        public efPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }


        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Books);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Books));

            if (purchase.OrderId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();


        }



    }
}
