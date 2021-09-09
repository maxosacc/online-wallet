using Core.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration
{
    //public class TransferTransactionConfiguration : IEntityTypeConfiguration<TransferTransaction>
    //{
    //    public void Configure(EntityTypeBuilder<TransferTransaction> modelBuilder)
    //    {
    //        modelBuilder.Property(a => a.Id).ValueGeneratedOnAdd();
    //        modelBuilder.Property(t => t.Amount).HasPrecision(12, 2);
    //        modelBuilder.Property(t => t.TransactionDateTime).HasColumnType("datetime");
    //    }
    //}
}
