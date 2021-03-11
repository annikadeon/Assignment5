using Assignment5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //add the DB context of what we created
            services.AddDbContext<BooksDbContext>(options =>
            {
                //pass in options to have the info we need, and set the connection strings
                //gives you the info of how to connect
                options.UseSqlite(Configuration["ConnectionStrings:AmazonBooksConnection"]);
            });
            //
            services.AddScoped<BooksRepository, EFBooksRepository>();
            //add services for razor pages
            services.AddRazorPages();
            //TO USE THE ADD TO CART BUTTON, get info to "stick'
            services.AddDistributedMemoryCache();
            services.AddSession();
            // specifies that the same object should be used to satisfy related requests for Cart instances
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            //same object should always be used
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            //when user clicks on sight, set up session to be able to navigatesite and keep stuff in the cart
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //change the url so it has P1 and P1 instead
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute("pageNum",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                //Customize the URL Mapping to work for /P
                "pagination",
                "Books/P{pageNum}",
                new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("pagination",
                "P{pageNum}",
                new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
                //add routing for razor pages

                endpoints.MapRazorPages();
            });
            //pass in seed data
           SeededData.EnsurePopulated(app);
        }
    }
}
