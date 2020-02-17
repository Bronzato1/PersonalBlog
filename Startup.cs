using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalBlog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using System.Globalization;
using System.Threading;

namespace PersonalBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConnectionForSqlServerLocaldb")));

            services
                .AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MyDbContext>();

            // services
            //     .AddMvc(option => option.EnableEndpointRouting = false)
            //     .AddRazorPagesOptions(options => { });

            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller=Dashboard}/{action=Index}/{id?}");
            //     routes.MapRoute(
            //         name: "identity",
            //         template: "{area=Identity}/{controller=Account}/{action=Login}/{id?}");
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Dashboard}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateRoles(services).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<CustomUser>>();

            var adminRoleExists = await RoleManager.RoleExistsAsync("Admin");

            if (!adminRoleExists)
                await RoleManager.CreateAsync(new IdentityRole("Admin"));

            var visitorRoleExists = await RoleManager.RoleExistsAsync("Visitor");

            if (!visitorRoleExists)
                await RoleManager.CreateAsync(new IdentityRole("Visitor"));

        }
    }
}
