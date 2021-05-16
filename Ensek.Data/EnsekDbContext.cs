using Ensek.Data.Entities;
using Ensek.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Data
{
    public class EnsekDbContext : DbContext
    {
        public EnsekDbContext(DbContextOptions<EnsekDbContext> options) : base(options) {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountsSeeder.Run(modelBuilder);

            modelBuilder.Entity<MeterReading>().HasKey(table => new
            {
                table.AccountId, table.ReadDate
            });
        }
    }
}
