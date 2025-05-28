using Microsoft.EntityFrameworkCore;

namespace Snackis.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Postings.Heading> Headings { get; set; }

    }
}
