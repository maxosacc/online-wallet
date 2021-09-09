using Common.EfCoreDbContext;
using Core.Domain.Entities.Transactions;
using Core.Domain.Repositories.Transactions;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions
{
    public class TransactionRepository : EfCoreRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CoreEfCoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
