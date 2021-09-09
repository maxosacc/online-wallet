using Common.EfCoreDbContext;
using Core.Domain.Entities;
using Core.Domain.Entities.Transactions;
using Core.Domain.Entities.Wallets;
using Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.EfCoreDataAccess
{
    public class CoreEfCoreDbContext : EfCoreDbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public CoreEfCoreDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserAccount
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            #endregion
            #region Transactions
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
