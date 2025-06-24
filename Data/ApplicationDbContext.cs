using Microsoft.EntityFrameworkCore;
using WebAPI.Handlers;
using WebAPI.Models.Entities;

namespace WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuoteFavorite> QuoteFavorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuoteFavorite>()
                .HasOne(qf => qf.Quote)
                .WithMany(q => q.QuoteFavorites)
                .HasForeignKey(qf => qf.QuoteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuoteFavorite>()
                .HasOne(qf => qf.User)
                .WithMany(u => u.QuoteFavorites)
                .HasForeignKey(qf => qf.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
