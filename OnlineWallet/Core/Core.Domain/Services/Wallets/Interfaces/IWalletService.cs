using System.Threading.Tasks;

namespace Core.Domain.Services.Wallets.Interfaces
{
    public interface IWalletService
    {
        Task<string> Deposit(string userIdentificationNumber, string password, int bankPin, string bankAccountNumber, decimal amount);
        Task<string> Withdraw(string userIdentificationNumber, string password, int bankPin, string bankAccountNumber, decimal amount);
        Task<string> Transfer(string userIdentificationNumber, string password, int bankPin, string userFromBankAccountNumber, string userToBankAccountNumber, decimal amount);
    }
}
