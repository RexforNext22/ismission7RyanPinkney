// Author Ryan Pinkney
// This is my model for the purchase orders

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ismission7RyanPinkney.Models
{
    public class Purchase
    {

        // Orderid will be the primary key
        [Key]
        [BindNever]
        public int OrderId { get; set; }

        // Initalize an ICollection of BasketLineItems
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        // Field for name
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        //Field for email
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }

        //Field for phone
        [Required(ErrorMessage = "Please enter an phone number")]
        public string Phone { get; set; }

        // Field for address
        [Required(ErrorMessage = "Please enter an address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        // Field for city
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        // Field for state
        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        // Field for zip
        public string Zip { get; set; }

        // Field for country
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }

        // For the blazor
        [BindNever]
        public bool OrderCompleted { get; set; }


    }
}
