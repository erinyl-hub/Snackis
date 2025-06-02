using Microsoft.EntityFrameworkCore;

namespace CodeAlongAPIr.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Car> Cars { get; set; }

    }
}
