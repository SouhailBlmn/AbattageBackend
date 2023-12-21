using Abattage_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Abattage_BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.Entity<ArticleBetail>()
                .HasMany(a => a.Types)
                .WithMany(t => t.Articles)
                .UsingEntity(j => j.ToTable("ArticlesTypseBetails"));

        }

        public DbSet<ArticleBetail> ArticlesBetails { get; set; }
        public DbSet<TypeBetail> TypesBetails { get; set; }
        public DbSet<Stabulation> Stabulations { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Carcasse> Carcasses { get; set; }
        public DbSet<AnimalStatus> AnimalStatuses { get; set; }
        public DbSet<ArticleStatus> ArticleStatuses { get; set; }
        public DbSet<TypeAbattage> TypeAbattages { get; set; }
        public DbSet<Chevillard> Chevillards { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Planification> Planifications { get; set; }


    }
}