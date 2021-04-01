using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities.Enums;
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
        Task<UserAccountDto> CreateUserTestMock(
            string firstName,
            string lastName,
            string userIdentificationNumber,
            BankType bankType,
            string bankAccountNumber,
            int bankPin);

        Task<int> LoginUser(string userIdentificationNumber, string password);
        Task<int> LogOut();

        Task<bool> ChangePassword(string oldPassword, string newPassword);
    }
}
