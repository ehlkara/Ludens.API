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

            base.OnModelCreating(modelBuilder);
        }
    }
}
