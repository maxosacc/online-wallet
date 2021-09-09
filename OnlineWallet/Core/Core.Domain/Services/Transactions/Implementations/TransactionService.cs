using Core.Domain.DTOs.Transactions;
using Core.Domain.Exceptions;
using Core.Domain.Repositories;
using Core.Domain.Services.Transactions.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Services.Transactions.Implementations
{
    public class TransactionService : ITransactionService
    {//TODO: Dodati implementaciju
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        public TransactionService(ICoreUnitOfWork coreUnitOfWork)
        {
            _coreUnitOfWork = coreUnitOfWork;
        }

        public async Task<List<TransactionDto>> GetAllTransactionByUserIdentificationNumber(string identificationNumber, string password)
        {
            var userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == identificationNumber.Trim() && userAcc.Password.Trim() == password);
            if (userAccount != null) throw new NotValidActionException($"User account with user identity: { identificationNumber } already exists.");

            var transactions = (await _coreUnitOfWork.TransactionRepository.GetAllWithIncludesAsList(transaction => transaction.FromBankAccount.IdentificationNumber == identificationNumber.Trim() && transaction.ToBankAccount.IdentificationNumber == identificationNumber));
            var transactionDtos = new List<TransactionDto>() ;
            transactions.ToList().ForEach(t => { transactionDtos.Add(new TransactionDto(t)); });
            return transactionDtos;
        }

        public async Task<TransactionDto> GetTransactionById(string identificationNumber, string password, int id)
        {
            var userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == identificationNumber.Trim() && userAcc.Password.Trim() == password);
            if (userAccount != null) throw new NotValidActionException($"User account with user identity: { identificationNumber } already exists.");
           
            var transaction = (await _coreUnitOfWork.TransactionRepository.GetFirstOrDefaultWithIncludes(transaction => transaction.Id == id && transaction.ToBankAccount.IdentificationNumber == identificationNumber));
            return new TransactionDto(transaction);
        }
    }
}
