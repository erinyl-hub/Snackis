using CodeAlongDI.Services;
using Microsoft.EntityFrameworkCore;

namespace CodeAlongDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Models.MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));

            builder.Services.AddHttpClient();

            builder.Services.AddTransient<UtilitiesToBeTransient>();
            builder.Services.AddScoped<UtilitesToBeScoped>();
            builder.Services.AddSingleton<UtilitesToBeSingeleton>();
            
            
            builder.Services.AddTransient<IUtilities, Utilities>();

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
