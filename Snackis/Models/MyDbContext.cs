using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snackis.Areas.Identity.Data;
using Snackis.Data;
using Snackis.Models.Postings;

namespace Snackis.Models
{
    public class MyDbContext : IdentityDbContext<SnackisUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Postings.Heading> Headings { get; set; }
        public DbSet<Models.Postings.Categorie> Categories { get; set; }
        public DbSet<Models.Postings.Post> Posts { get; set; }
        public DbSet<Models.Postings.Comment> Comments { get; set; }
        //public DbSet<Models.Messages.Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Heading>()
                .HasOne(b => b.Categorie)
                .WithMany(g => g.Headings)
                .HasForeignKey(b => b.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(b => b.Heading)
                .WithMany(g => g.Posts)
                .HasForeignKey(b => b.HeadingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.SnackisUser)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.SnackisUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SnackisUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.SnackisUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SnackisUser>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<SnackisUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.SnackisUser)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Models.Messages.Message>()
            //    .HasOne(m => m.Sender)
            //    .WithMany(u => u.SentMessages)
            //    .HasForeignKey(m => m.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Models.Messages.Message>()
            //    .HasOne(m => m.Receiver)
            //    .WithMany(u => u.ReceivedMessages)
            //    .HasForeignKey(m => m.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<SnackisUser>()
            //    .Ignore(u => u.ReceivedMessages);

            //modelBuilder.Entity<SnackisUser>()
            //    .Ignore(u => u.SentMessages);
        }
    }
}
