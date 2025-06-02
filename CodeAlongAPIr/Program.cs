
using CodeAlongAPIr.Data;
using CodeAlongAPIr.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeAlongAPIr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("MyConnection");
            Console.WriteLine("Connectionstring: " + connectionString);

            builder.Services.AddDbContext<Models.MyDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<CarManager>();
           


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
