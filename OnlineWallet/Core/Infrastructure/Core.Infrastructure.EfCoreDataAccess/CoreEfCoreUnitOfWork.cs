using Common.EfCoreDbContext;
using Core.Domain.Repositories;
using Core.Domain.Repositories.Transactions;
using Core.Domain.Repositories.Wallets;
using Core.Infrastructure.EfCoreDataAccess.Repositories;
using Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions;
using Core.Infrastructure.EfCoreDataAccess.Repositories.Wallets;

namespace Core.Infrastructure.EfCoreDataAccess
{
    public class CoreEfCoreUnitOfWork : EfCoreUnitOfWork, ICoreUnitOfWork
    {
        public IUserAccountRepository UserAccountRepository { get; }

        public ITransactionRepository TransactionRepository { get; }
        public IWalletRepository WalletRepository { get; }

        public CoreEfCoreUnitOfWork(CoreEfCoreDbContext context) : base(context)
        {
            UserAccountRepository = new UserAccountRepository(context);
            TransactionRepository = new TransactionRepository(context);
            WalletRepository = new WalletRepository(context);
        }
    }
}
