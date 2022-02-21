﻿// Author Ryan Pinkney
// This file is automatically generated by VS but I edited the services


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ismission7RyanPinkney.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

            // Add this to add the repository; service configuration for the repository
            services.AddScoped<iBookstoreRepository, efBookstoreRepository>();



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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // This one first
                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{category}/{iPageNum}",
                    defaults: new { Controller = "Home", action = "List" });

                // This one first
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{iPageNum}",
                    defaults: new { Controller = "Home", action = "List", iPageNum = 1 });


                // This one first
                endpoints.MapControllerRoute(
                    name: "type",
                    pattern: "{category}",
                    defaults: new { Controller = "Home", action = "List", iPageNum = 1 });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
