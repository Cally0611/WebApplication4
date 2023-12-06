using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Configuration;
using WebApplication4.Data;
using WebApplication4.Service;
using WebApplication4.Helpers;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Models;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<DBOperationService>();
            builder.Services.AddScoped<IOEERepository, DBOperationService>();
            builder.Services.AddDbContext<OeedashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OEEDashboardCon")));
            builder.Services.AddEndpointsApiExplorer();
    

            builder.Services.AddScoped<DateTimeHelper>();
            //builder.Services.AddHostedService<TimedHostedService>();
            builder.Services.AddHostedService((sp) => sp.GetRequiredService<TimedHostedService>());
            builder.Services.AddSingleton<TimedHostedService>();

            //Store config settings in one object
            builder.Services.Configure<Shift>(builder.Configuration.GetSection("ShiftSettings"));
            builder.Services.AddTransient<ITransientService, ShiftsService>();

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

            app.Logger.LogInformation("Starting the app");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Chart}/{id?}");
            app.MapControllerRoute(
                name: "DefaultApi",
                pattern: "api/{controller}/{id}");
            app.Run();
        }
    }
}