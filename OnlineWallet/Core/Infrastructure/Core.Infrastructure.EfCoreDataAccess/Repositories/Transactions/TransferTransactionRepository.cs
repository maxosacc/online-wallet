using Common.EfCoreDbContext;
using Core.Domain.Entities.Transactions;
using Core.Domain.Repositories.Transactions;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions
{
    public class TransferTransactionRepository : EfCoreRepository<TransferTransaction>, ITransferTransactionRepository
    {
        public TransferTransactionRepository(CoreEfCoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
