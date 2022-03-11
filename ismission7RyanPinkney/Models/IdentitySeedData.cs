// Author Ryan Pinkney
// This is my seeddata file for the admin user


using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ismission7RyanPinkney.Models
{
    public class IdentitySeedData
    {
        // Set the const for username and password
        private const string adminUser = "Admin";
        private const string adminPassword = "413ExtraYeetPeriod(t)!";


        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppIdentityDBContext>();


            // Determine if there are pending migrations and make the migrations
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                    .CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Seed the data
            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);

                // Set the email and phone number for the admin user
                user.Email = "test@test.com";
                user.PhoneNumber = "8014225667";

                // Create the user
                await userManager.CreateAsync(user, adminPassword);


            }







        }
    }
}