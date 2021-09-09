using Core.Domain.DTOs.Transactions;
using Core.Domain.Repositories;
using Core.Domain.Services.Transactions.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Services.Transactions.Implementations
{
    public class TransferTransactionService
    {//TODO : DODATI IMPLEMENTACIJU
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        public TransferTransactionService(ICoreUnitOfWork coreUnitOfWork)
        {
            _coreUnitOfWork = coreUnitOfWork;
        }

        //public Task<TransferTransactionDto> Create(TransferTransactionDto internalTransactionDto)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<TransferTransactionDto> GetInternalTransactionById(int internalTransactionId, string userIdentificationNumber, string password)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<List<TransferTransactionDto>> GetInternalTransactionsByUser(string userIdentificationNumber, string password)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
