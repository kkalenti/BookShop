using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IRepository<Book>, SqlBookRepository>();
            services.AddScoped<IRepository<Carousel>, SqlCarouselRepository>();
            services.AddScoped<IRepository<Order>, SqlOrderRepository>();
            services.AddScoped<IRepository<Section>, SqlSectionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });

            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var content = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
            //    DbObjects.Initial(content);
            //}
        }
    }
}
