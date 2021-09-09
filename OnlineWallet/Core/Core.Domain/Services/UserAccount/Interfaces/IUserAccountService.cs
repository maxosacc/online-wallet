using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface IUserAccountService
    {
        Task<UserAccountDto> CreateUser(
            string firstName,
            string lastName,
            string userIdentificationNumber,
            BankType bankType,
            string bankAccountNumber,
            int bankPin);
        Task<bool> ChangePassword(string userIdentificationNumber, string oldPassword, string newPassword, string newPasswordRepeated);
        Task<bool> LoginAsAdmin(string password);
        
        Task<decimal> GetUserAccountBalance(string userIdentificationNumber, string bankPin);

        Task<List<UserAccountDto>> GetAllUsers(string adminPassword);
        Task<bool> BlockUser(string adminPassword, int id);
        Task<bool> UnBlockUser(string adminPassword, int id);
    }
}
