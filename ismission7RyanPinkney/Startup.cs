﻿// Author Ryan Pinkney
// This file is automatically generated by VS but I edited the services


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ismission7RyanPinkney.Models;
using ismission7RyanPinkney.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static ismission7RyanPinkney.Models.iBookstoreRepository;

namespace ismission7RyanPinkney
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            // Add this to connect the database sqlite
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionString:RPConnection"]);
            });

            // Set up for the identity database
            services.AddDbContext<AppIdentityDBContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionString:IdentityConnection"]);

            });


            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDBContext>();



            // Add this to add the repository; service configuration for the repository
            services.AddScoped<iBookstoreRepository, efBookstoreRepository>();
            services.AddScoped<iPurchaseRepository, efPurchaseRepository>();

            // Add this to add razor pages
            services.AddRazorPages();


            // Add the session service
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Add the service for the session basket
            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add these services for the admin
            // Blazor Services
            services.AddServerSideBlazor();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Add this for sessions; added by ryan
            app.UseSession();
            app.UseRouting();


            // For Identity set up
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // This one first
                // Endpoint for when we have a category and a page number
                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{category}/{iPageNum}",
                    defaults: new { Controller = "Home", action = "List" });

                // This one first
                // Endpoint for when we just have an page number
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{iPageNum}",
                    defaults: new { Controller = "Home", action = "List", iPageNum = 1 });


                // This one first
                // Endpoint for when we just have a category
                endpoints.MapControllerRoute(
                    name: "type",
                    pattern: "{category}",
                    defaults: new { Controller = "Home", action = "List", iPageNum = 1 });

                // Endpoint for the default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                // This is second
                endpoints.MapDefaultControllerRoute();


                // Add this for Razor pages
                endpoints.MapRazorPages();

                // Blazor endpoints
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

            });


            // Seed the admin user
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
