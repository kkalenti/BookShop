using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(dbContextOptionBuilder =>
                dbContextOptionBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddIdentity<User, IdentityRole>(
            //x =>
            //{
            //    x.Password.RequireDigit = ,

            //}
            //Here i can set different kind of properties for password, user or the number of attempts to authorize ond etc.
            ).AddEntityFrameworkStores<BookStoreDbContext>();
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddScoped<IRepository<Book>, SqlBookRepository>();
            services.AddScoped<IRepository<Carousel>, SqlCarouselRepository>();
            services.AddScoped<IRepository<Order>, SqlOrderRepository>();
            services.AddScoped<IRepository<Section>, SqlSectionRepository>();
            services.AddScoped<IRepository<Country>, MockCountryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/Error/PageNotFound";
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}
