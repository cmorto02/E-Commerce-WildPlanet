using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.data;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.Handlers;
using MyShop.Models.Interfaces;
using MyShop.Models.Services;

namespace MyShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            /*string connectionString = Environment.IsDevelopment()
                                       ? Configuration["ConnectionString:DefaultConnection"]
                                       : Configuration["ConnectionString:ProductionConnection"]; 
           services.AddDbContext<MyShopDbContext>(options => options.UseSqlServer(connectionString));*/

            services.AddAuthorization(options =>
            {
                options.AddPolicy("LovesAnimals", policy => policy.Requirements.Add(new LovesAnimals()));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("IdentityDefault")));


            services.AddDbContext<MyShopDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IInventoryManager, InventoryService>();
            services.AddScoped<IBasketManager, BasketService>();

            services.AddScoped<IAuthorizationHandler, LovesAnimalsHandler>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
