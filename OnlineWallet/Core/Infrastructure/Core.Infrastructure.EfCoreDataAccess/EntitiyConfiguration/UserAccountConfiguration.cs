using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.EfCoreDataAccess.EntitiyConfiguration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.FirstName).HasMaxLength(30);
            builder.Property(t => t.LastName).HasMaxLength(30);
            builder.Property(t => t.IdentificationNumber).HasMaxLength(30);
            builder.Property(t => t.BankAccountNumber).HasMaxLength(30);
        }
    }
}
