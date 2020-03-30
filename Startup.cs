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

            string connectionStringForSqlite = Configuration.GetConnectionString("ConnectionForSqlite");            
            string appRoot = Environment.CurrentDirectory;

            services.AddDbContext<MyDbContext> (options => 
                options.UseSqlite(connectionStringForSqlite.Replace("{appRoot}", appRoot))
                //options.UseSqlServer(Configuration.GetConnectionString("ConnectionForSqlServerLocaldb"))
                //options.UseSqlServer(Configuration.GetConnectionString("ConnectionForSqlServerExpress"))
            );

            services
                .AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MyDbContext>();

            // services
            //     .AddMvc(option => option.EnableEndpointRouting = false)
            //     .AddRazorPagesOptions(options => { });

            // https://www.talkingdotnet.com/handle-ajax-requests-in-asp-net-core-razor-pages/
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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

            app.UseEndpoints(endpoints =>
            {

                // endpoints.MapAreaControllerRoute(
                //     name: "areas", 
                //     areaName: "xxxx", 
                //     pattern: "{area:exists}/{controller=Xxxxx}/{action=Index}/{id?}");  

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "quizzes/",
                    defaults: new { controller = "Home", action = "Index" }
                );
                            
                endpoints.MapControllerRoute(
                    name: "QuizzesList",
                    pattern: "quizzes/",
                    defaults: new { controller = "Quiz", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "NewQuiz",
                    pattern: "quizzes/new/",
                    defaults: new { controller = "Quiz", action = "NewQuiz" }
                );

                endpoints.MapRazorPages();
            });

            CreateRoles(services).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<CustomUser>>();

            var adminRoleExists = await RoleManager.RoleExistsAsync("Admin");
            var authorRoleExists = await RoleManager.RoleExistsAsync("Author");
            var visitorRoleExists = await RoleManager.RoleExistsAsync("Visitor");

            if (!adminRoleExists)
                await RoleManager.CreateAsync(new IdentityRole("Admin"));

            if (!authorRoleExists)
                await RoleManager.CreateAsync(new IdentityRole("Author"));

            if (!visitorRoleExists)
                await RoleManager.CreateAsync(new IdentityRole("Visitor"));

        }
    }
}
