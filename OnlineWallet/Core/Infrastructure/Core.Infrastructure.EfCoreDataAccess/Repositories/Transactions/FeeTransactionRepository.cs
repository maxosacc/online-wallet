using Common.EfCoreDbContext;
using Core.Domain.Entities.Transactions;
using Core.Domain.Repositories.Transactions;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories.Transactions
{
    public class FeeTransactionRepository : EfCoreRepository<FeeTransaction>, IFeeTransactionRepository
    {
        public FeeTransactionRepository(CoreEfCoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
