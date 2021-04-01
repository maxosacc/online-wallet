using Core.ApplicationServices;
using Core.ApplicationServices.Bank;
using Core.ApplicationServices.Services.Bank;
using Core.Domain.Repositories;
using Core.Infrastructure.EfCoreDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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

        [TestCleanup()]
        public async Task Cleanup()
        {
            await _dbContext.DisposeAsync();
            _coreUnitOfWork = null;
        }

        [TestMethod]
        public async Task CreateUserTest()
        {
            //Arrange
            //BANK API MUST BE STARTED!
            TestBankService bankService = new TestBankService();
            UserAccountService userAccountService = new UserAccountService(_coreUnitOfWork, bankService);

            //Act
            Core.Domain.DTOs.UserAccounts.UserAccountDto user = await userAccountService.CreateUserTestMock("ime", "prezime", "3108902211", Core.Domain.Entities.Enums.BankType.XomaBank, "01234", 1234);
            //Assert
            Core.Domain.Entities.UserAccount userDb = await _coreUnitOfWork.UserAccountRepository.GetById(user.Id);

            Assert.AreEqual(user.FirstName,userDb.FirstName, "FirstName must be same!");
            Assert.AreEqual(user.LastName,userDb.LastName, "LastName must be same!");
            Assert.AreEqual(user.IdentificationNumber,userDb.IdentificationNumber, "IdentificationNumber must be same!");
            Assert.AreEqual(user.Bank,userDb.Bank, "Bank must be same!");
            Assert.AreEqual(user.BankAccountNumber,userDb.BankAccountNumber, "BankAccountNumber must be same!");
            Assert.AreEqual(user.Password,userDb.Password, "BankAccountNumber must be same!");
        }
    }
}