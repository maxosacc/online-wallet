﻿using Common.EfCoreDbContext;
using Core.Domain.Entities;
using Core.Domain.Entities.Transactions;
using Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.EfCoreDataAccess
{
    public class CoreEfCoreDbContext : EfCoreDbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<FeeTransaction> FeeTransactions { get; set; }
        public DbSet<InternalTransaction> InternTransactions { get; set; }
        public DbSet<TransferTransaction> TransferTransactions { get; set; }

        public CoreEfCoreDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserAccount
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            #endregion
            #region Transactions
            modelBuilder.ApplyConfiguration(new FeeTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new InternalTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransferTransactionConfiguration());


            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
