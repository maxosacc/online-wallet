using System.Threading.Tasks;

namespace Core.Domain.Services.Banks
{
    public interface IBankService
    {
        Task<string> ValidateUserBankAccountAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin);
        Task<string> ValidateUserBankAccountAndGeneratePasswordTestMock(string userIdentificationNumber, string bankAccountNumber, int bankPin);
        Task<bool> CheckStatus(string userIdentificationNumber, int bankPin);
        Task<bool> Deposit(string userIdentificationNumber, int bankPin, decimal amount);
        Task<bool> Withdraw(string userIdentificationNumber, int bankPin, decimal amount);
        Task<bool> Transfer(string userIdentificationNumber, int bankPin, decimal amount, string bankAccountNumberReciever);
    }
}
