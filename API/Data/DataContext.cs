using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<PortfolioNode> PortfolioNodes { get; set; }

        public DbSet<NodeName> NodeNames { get; set; }

        public DbSet<AuthToken> AuthTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Portfolio and PortfolioNode
            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.Nodes)
                .WithOne()
                .HasForeignKey("PortfolioId"); // I may need to adjust the foreign key property name

            // Configure the relationship between Portfolio and NodeNames
            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.NodeNames)
                .WithMany()
                .UsingEntity(j => j.ToTable("PortfolioNodeNames"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
