using Core.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> modelBuilder)
        {
            modelBuilder.Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Property(t => t.Amount).HasPrecision(12, 2);
            modelBuilder.Property(t => t.TransactionDateTime).HasColumnType("datetime");
        }
    }
}
