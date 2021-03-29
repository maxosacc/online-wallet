using Core.Domain.Repositories;
using Core.Infrastructure.EfCoreDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ApplicationServicesTests
{
    [TestClass]
    public class Tests
    {
        private ICoreUnitOfWork _coreUnitOfWork;
        private CoreEfCoreDbContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            var dbContextFactory = new SampleDbContextFactory();
            _dbContext = dbContextFactory.CreateDbContext(new string[] { });
            _coreUnitOfWork = new CoreEfCoreUnitOfWork(_dbContext);
        }

        public void Test1()
        {
            //Assert.Pass();
        }
    }
}