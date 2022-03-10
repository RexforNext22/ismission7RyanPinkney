using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ismission7RyanPinkney.Models
{

    // Inherit from the identity db context file with the identity user
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {

        // Constructor
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {


        }



    }
}
