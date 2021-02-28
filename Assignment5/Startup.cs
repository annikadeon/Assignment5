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
                options.UseSqlServer(Configuration["ConnectionStrings:AmazonBooksConnection"]);
            });
            //
            services.AddScoped<BooksRepository, EFBooksRepository>();

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

            //change the url so it has P1 and P1 instead
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("pagination",
                "P{page}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
            });
            //pass in seed data
            SeededData.EnsurePopulated(app);
        }
    }
}
