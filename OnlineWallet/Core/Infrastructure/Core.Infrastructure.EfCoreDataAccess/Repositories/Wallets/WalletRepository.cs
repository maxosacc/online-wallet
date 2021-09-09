using Common.EfCoreDbContext;
using Core.Domain.Entities.Wallets;
using Core.Domain.Repositories.Wallets;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories.Wallets
{
    public class WalletRepository : EfCoreRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(EfCoreDbContext context) : base(context)
        {
        }
    }
}
