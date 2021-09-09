using Common.Utils;
using Core.Domain.Repositories.Transactions;

namespace Core.Domain.Repositories
{
    public interface ICoreUnitOfWork : IUnitOfWork
    {
        public IUserAccountRepository UserAccountRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
    }
}
