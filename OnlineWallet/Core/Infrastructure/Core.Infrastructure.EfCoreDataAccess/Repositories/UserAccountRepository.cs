using Common.EfCoreDbContext;
using Core.Domain.Entities;
using Core.Domain.Repositories;

namespace Core.Infrastructure.EfCoreDataAccess.Repositories
{
    public class UserAccountRepository : EfCoreRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(CoreEfCoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
