using Ludens.Models.Entities.Ludens;
using Microsoft.EntityFrameworkCore;

namespace Ludens.Core.Context
{
    public class LudensDbContext : DbContext
    {
        public LudensDbContext(DbContextOptions<LudensDbContext> options) : base(options) { }

        public DbSet<Funds> Funds { get; set; }
        public DbSet<FundPrices> FundPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundPrices>().HasOne(p => p.Funds).WithMany(p => p.FundPrices).HasForeignKey(p => p.FundId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
