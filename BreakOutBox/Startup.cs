﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BreakOutBox.Data;
using BreakOutBox.Models;
using BreakOutBox.Services;
using BreakOutBox.Models.Domain;
using BreakOutBox.Data.Repositories;
using System.Security.Claims;
using BreakOutBox.Filters;

namespace BreakOutBox
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options => {
                options.AddPolicy("leerkrachtAuth", policy => policy.RequireClaim(ClaimTypes.Role, "leerkracht"));
            });

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Leerkracht/Index");

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();         
            services.AddScoped<ISessieRepository, SessieRepository>();
            services.AddScoped<ILeerkrachtRepository, LeerkrachtRepository>();
            services.AddScoped<BreakOutBoxDataInitializer>();
            services.AddScoped<ClearSessionFilter>();
            services.AddScoped<ClearGroepSessionFilter>();
            services.AddScoped<ClearSessieSessionFilter>();
            services.AddScoped<SessieEnGroepSessionFilter>();
            services.AddScoped<LeerkrachtFilter>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BreakOutBoxDataInitializer breakOutBoxDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            breakOutBoxDataInitializer.InitializeData().Wait();
        }
    }
}
