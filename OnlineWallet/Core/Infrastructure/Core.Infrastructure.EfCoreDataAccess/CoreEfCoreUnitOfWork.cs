using Common.EfCoreDbContext;
using Core.Domain.Repositories;
using Core.Domain.Repositories.Transactions;
using Core.Infrastructure.EfCoreDataAccess.Repositories;
using Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions;

namespace Core.Infrastructure.EfCoreDataAccess
{
    public class CoreEfCoreUnitOfWork : EfCoreUnitOfWork, ICoreUnitOfWork
    {
        public IUserAccountRepository UserAccountRepository { get; }

        public IFeeTransactionRepository FeeTransactionRepository { get; }

        public IInternalTransactionRepository InternalTransactionRepository { get; }

        public ITransferTransactionRepository TransferTransactionRepository { get; }

        public CoreEfCoreUnitOfWork(CoreEfCoreDbContext context) : base(context)
        {
            UserAccountRepository = new UserAccountRepository(context);
            FeeTransactionRepository = new FeeTransactionRepository(context);
            InternalTransactionRepository = new InternalTransactionRepository(context);
            TransferTransactionRepository = new TransferTransactionRepository(context);
        }
    }
}
