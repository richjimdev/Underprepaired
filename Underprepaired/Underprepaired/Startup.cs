﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Underprepaired.Data;
using Underprepaired.Models;
using Underprepaired.Models.Handlers;
using Underprepaired.Models.Interfaces;
using Underprepaired.Models.Services;

namespace Underprepaired
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

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

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<UnderprepairedDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ProductionDB"]);
            }
            );

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ProductionIDDB"]);
            }
            );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("FounderEmailPolicy", policy => policy.Requirements.Add(new EmailRequirement()));
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRoles.Admin));
            });

            services.AddScoped<IAuthorizationHandler, UnderprepairedEmailHandler>();
            services.AddTransient<IInventory, InventoryService>();
            services.AddTransient<ICart, CartService>();
            services.AddScoped<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
        }
    }
}
