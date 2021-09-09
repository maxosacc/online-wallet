using Core.Domain.Repositories;

namespace Core.Domain.Services.Transactions.Implementations
{
    public class InternalTransactionService
    {//TODO: Dodati implementaciju
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        public InternalTransactionService(ICoreUnitOfWork coreUnitOfWork)
        {
            _coreUnitOfWork = coreUnitOfWork;
        }

        //public Task<InternalTransactionDto> GetInternalTransactionById(int internalTransactionId, string userIdentificationNumber, string password)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<List<InternalTransactionDto>> GetInternalTransactionsByUser(string userIdentificationNumber, string password)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
