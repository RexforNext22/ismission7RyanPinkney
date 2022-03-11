// Author Ryan Pinkney
// This is my login model for the admin username


using System;
using System.ComponentModel.DataAnnotations;

namespace ismission7RyanPinkney.Models.ViewModels
{
    public class Login
    {
        // Attribute for the username
        [Required]
        public string Username { get; set; }

        // Attribute for the password
        [Required]
        public string Password { get; set; }

        // Attribute for the return url
        public string ReturnUrl { get; set; }


    }
}
