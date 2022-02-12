﻿// Author Ryan Pinkney
// This is my iRepository file to set up the repository and inferacae

using System;
using System.Linq;

namespace ismission7RyanPinkney.Models
{


        // Define the interface
        public interface iBookstoreRepository
        {
            // Set the iQueryable
            IQueryable<Books> Books { get; }

        }

}
