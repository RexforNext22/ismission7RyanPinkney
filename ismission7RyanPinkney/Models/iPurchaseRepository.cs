// Author Ryan Pinkney
// This is my interface for the purchase repository

using System;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
    public interface iPurchaseRepository
    {
        // Set the iqueryable
        IQueryable<Purchase> Purchases { get; }

        void SavePurchase (Purchase purchase);




    }
}
