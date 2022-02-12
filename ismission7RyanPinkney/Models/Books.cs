// Author Ryan Pinkney
// This is my model that I scoffolded in from the database

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ismission7RyanPinkney.Models
{
    public partial class Books
    {

        // Field to store the book id
        // Changed to integer
        [Required]
        [Key]
        public int BookId { get; set; }

        // Field to store the title
        public string Title { get; set; }

        // Field to store the author
        public string Author { get; set; }

        // Field to store the publisher
        public string Publisher { get; set; }

        // Field to store the ISBN
        public string Isbn { get; set; }

        // Field to store the classification
        public string Classification { get; set; }

        // Field to store the category
        public string Category { get; set; }

        // Changed to an integer
        public int PageCount { get; set; }

        // Changed to a decomial which is better for money
        public decimal Price { get; set; }
    }
}
