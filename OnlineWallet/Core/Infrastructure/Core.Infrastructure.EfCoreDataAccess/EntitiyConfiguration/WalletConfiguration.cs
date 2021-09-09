using Core.Domain.Entities.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> modelBuilder)
        {
            modelBuilder.Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Property(t => t.Balance).HasPrecision(12, 2);
            modelBuilder.Property(t => t.CreatedDate).HasColumnType("datetime");
        }
    }
}
