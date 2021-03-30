using Common.EfCoreDbContext;
using Core.Domain.Entities.Transactions;
using Core.Domain.Repositories.Transactions;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions
{
    public class InternalTransactionRepository : EfCoreRepository<InternalTransaction>, IInternalTransactionRepository
    {
        public InternalTransactionRepository(CoreEfCoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
