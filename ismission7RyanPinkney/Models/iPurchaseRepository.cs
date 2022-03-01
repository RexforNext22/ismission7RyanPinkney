// Author Ryan Pinkney
// This is my interface for the purchase repository

using System;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
    public class iPurchaseRepository
    {
        // Set the iqueryable
        IQueryable<Purchase> Purchases { get; }

        public void SavePurchase(Purchase purchase);




    }
}
