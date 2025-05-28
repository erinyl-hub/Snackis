using Microsoft.EntityFrameworkCore;

namespace CodeAlongDI.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Car> Cars { get; set; }
    }
}
