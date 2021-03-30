using Common.Utils;
using Core.Domain.Repositories.Transactions;

namespace Core.Domain.Repositories
{
    public interface ICoreUnitOfWork : IUnitOfWork
    {
        public IUserAccountRepository UserAccountRepository { get; }
        public IFeeTransactionRepository FeeTransactionRepository { get; }
        public IInternalTransactionRepository InternalTransactionRepository { get; }
        public ITransferTransactionRepository TransferTransactionRepository { get; }
    }
}
