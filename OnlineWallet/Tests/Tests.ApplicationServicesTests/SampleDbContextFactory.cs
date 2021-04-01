using Core.Infrastructure.EfCoreDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tests.ApplicationServicesTests
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<CoreEfCoreDbContext>
    {
        public CoreEfCoreDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CoreEfCoreDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=testDB;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            return new CoreEfCoreDbContext(options);
        }
    }
}
