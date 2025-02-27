using FirstCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC__Core_Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
         //  builder.Services.AddControllersWithViews(); // registered mvc as a service
           builder.Services.AddControllersWithViews();
            /* builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("B24WEBAPI8TestProject")));*/

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WEBAPI8TestProject")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


           /* app.MapControllerRoute(
               name: "defaultbyname",
               pattern: "{controller=Customer}/{action=Index}/{name}");*/

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
