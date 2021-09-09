using Core.Domain.DTOs.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Services.Transactions.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto> GetTransactionById(string identificationNumber, string password, int id);
        Task<List<TransactionDto>> GetAllTransactionByUserIdentificationNumber(string identificationNumber, string password);
    }
}
