// Author Ryan Pinkney
// This is my basket model

using System;
using System.Collections.Generic;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
        public class Basket
        {

            // Properties for our basket
            // Declare and initalize in the same line
            public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

            // Public void is a method
            public void AddItem(Books book, int qty)
            {
                BasketLineItem Line = Items.Where(x => x.Books.BookId == book.BookId).FirstOrDefault();

                if (Line is null)
                {
                    Items.Add(new BasketLineItem
                    {
                        Books = book,
                        Quantity = qty
                    });
                }
                else
                {
                    Line.Quantity += qty;
                }
            }

            public double CalcualteTotal()
            {
                double sum = (double) Items.Sum(x => x.Quantity * x.Books.Price);

                return sum;
            }

        }



        public class BasketLineItem
        {

            // Properties for our basket
            public int LineId { get; set; }

            public Books Books { get; set; }

            public int Quantity { get; set; }


        }
    }

