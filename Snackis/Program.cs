using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Snackis.Data;
using Snackis.Areas.Identity.Data;
using Snackis.Models;
using Snackis.Services;

namespace Snackis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Models.MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext") ?? throw new InvalidOperationException("Anslutning till DB hittades inte")));

            builder.Services.AddDbContext<Snackis.Data.SnackisContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext") ?? throw new InvalidOperationException("Anslutning till DB hittades inte")));

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.SnackisUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SnackisContext>();

            var config = builder.Configuration;
            var ApiUrl = config["ApiSettings:ReportApiUrl"];

            builder.Services.AddHttpClient("ReportApi", client =>
            {
                client.BaseAddress = new Uri(ApiUrl);
            });

            builder.Services.AddScoped<MyService>();



            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
