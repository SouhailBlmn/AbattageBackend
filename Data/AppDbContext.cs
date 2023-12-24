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


            // Configure the many-to-many relationship
            modelBuilder.Entity<ArticleTypeBetail>()
                .HasKey(at => new { at.ArticleBetailId, at.TypeBetailId });

            modelBuilder.Entity<ArticleTypeBetail>()
                .HasOne(at => at.ArticleBetail)
                .WithMany(a => a.ArticleTypeBetails)
                .HasForeignKey(at => at.ArticleBetailId);

            modelBuilder.Entity<ArticleTypeBetail>()
                .HasOne(at => at.TypeBetail)
                .WithMany(t => t.ArticleTypeBetails)
                .HasForeignKey(at => at.TypeBetailId);

            // Configure the table name for the join entity
            modelBuilder.Entity<ArticleTypeBetail>().ToTable("ArticlesTypesBetails");

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
        public DbSet<ArticleParAnimal> ArticleParAnimals { get; set; }
        public DbSet<ArticleTypeBetail> ArticlesTypesBetails { get; set; }
        public DbSet<Depot> Depots { get; set; }



    }
}