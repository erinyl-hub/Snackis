using Microsoft.EntityFrameworkCore;
using Snackis.Models.Postings;

namespace Snackis.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Postings.Heading> Headings { get; set; }
        public DbSet<Models.Postings.Categorie> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Heading>()
                .HasOne(b => b.Categorie)
                .WithMany(g => g.Headings)
                .HasForeignKey(b => b.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
