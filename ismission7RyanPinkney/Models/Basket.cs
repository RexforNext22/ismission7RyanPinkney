// Author Ryan Pinkney
// This is my basket model

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ismission7RyanPinkney.Models
{
    public class Basket
    {

        // Properties for our basket
        // Declare and initalize in the same line
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // Public void is a method
        public virtual void AddItem(Books book, int qty)
        {
            BasketLineItem Line = Items.Where(x => x.Books.BookId == book.BookId).FirstOrDefault();

            if (Line is null) // Add the item to the list of basket
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

        // Method to calculate the total
        public double CalcualteTotal()
        {
            double sum = (double)Items.Sum(x => x.Quantity * x.Books.Price); // Use the price of the book here to calculate the total

            return sum;
        }




        // Method to remove an item from the basket
        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Books.BookId == book.BookId);
        }

        // Method to clear the basket
        public virtual void ClearBasket()
        {
            Items.Clear();
        }

    }

    // Class to hold each of the properties of our basket
    public class BasketLineItem
        {

        // Properties for our basket
        [Key]
        public int LineId { get; set; }

        public Books Books { get; set; }

        public int Quantity { get; set; }


        }
    }

