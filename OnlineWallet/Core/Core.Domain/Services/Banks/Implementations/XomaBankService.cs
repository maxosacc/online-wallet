using Core.Domain.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Core.Domain.Services.Banks.Implementations
{
    public class XomaBankService : IBankService
    {//TODO: dodati implementaciju mock-a
        public HttpClient Http { get; private set; }
        public XomaBankService()
        {
            Http = new HttpClient();
        }
        public async Task<bool> CheckStatus(string userIdentificationNumber, int bankPin)
        {
            try
            {
                await CheckUserPinAndBankServiceStatus(bankPin);
                var bankAPIResponse = await Http.PostAsJsonAsync("https://localhost:5001/BankAccount/ValidateUser", new { UserIdentificationNumber = userIdentificationNumber, BankAccountNumber = "", Pin = bankPin.ToString() });

                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Deposit(string userIdentificationNumber, int bankPin, decimal amount)
        {
            try
            {
                await CheckUserPinAndBankServiceStatus(bankPin);
                var bankAPIResponse = await Http.PostAsJsonAsync("https://localhost:5001/BankAccount/Deposit", new { UserIdentificationNumber = userIdentificationNumber, BankAccountNumber = "", Pin = bankPin.ToString() });
                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Withdraw(string userIdentificationNumber, int bankPin, decimal amount)
        {
            try
            {
                await CheckUserPinAndBankServiceStatus(bankPin);
                var bankAPIResponse = await Http.PostAsJsonAsync("https://localhost:5001/BankAccount/Withdraw", new { UserIdentificationNumber = userIdentificationNumber, BankAccountNumber = "", Pin = bankPin.ToString() });
                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Transfer(string userIdentificationNumber, int bankPin, decimal amount, string bankAccountNumberReciever)
        {
            try
            {
                await CheckUserPinAndBankServiceStatus(bankPin);
                var bankAPIResponse = await Http.PostAsJsonAsync("https://localhost:5001/BankAccount/Transfer", new { UserIdentificationNumber = userIdentificationNumber, BankAccountNumber = "", Pin = bankPin.ToString(), RecieverBankAccountNumber = bankAccountNumberReciever });
                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> ValidateUserBankAccountAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin)
        {
            await CheckUserPinAndBankServiceStatus(bankPin);
            //http call to BankAPI to validate user
            try
            {
                var newPassword = await ValidateBankAccountAndGeneratePassword(userIdentificationNumber, bankAccountNumber, bankPin);
                return newPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task CheckUserPinAndBankServiceStatus(int bankPin)
        {
            if (bankPin <= 0 || bankPin > 9999) throw new ArgumentNullException("Bank pin is not valid!");

            //http call to BankAPI to check status and another to validate user
            bool isAPIActive = await CheckBankServiceStatus();
            if (!isAPIActive) throw new BankAPINotRespondingException("XomaBank is not responding!");
        }

        private async Task<bool> CheckBankServiceStatus()
        {
            try
            {
                var bankAPIResponse = await Http.GetAsync("https://localhost:5001/HealthCheck/CheckStatus");

                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<string> ValidateBankAccountAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin)
        {
            try
            {
                var bankAPIResponse = await Http.PostAsJsonAsync("https://localhost:5001/BankAccount/ValidateUserAndGetPassword", new { UserIdentificationNumber = userIdentificationNumber , BankAccountNumber = bankAccountNumber, Pin = bankPin.ToString() });

                if (!bankAPIResponse.IsSuccessStatusCode)
                {
                    throw new NotFoundException("BankAPI not responding!");
                }
                var responseContent = await bankAPIResponse.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> ValidateUserBankAccountAndGeneratePasswordTestMock(string userIdentificationNumber, string bankAccountNumber, int bankPin)
        {
            if (bankPin <= 0) throw new ArgumentNullException("Bank pin is not valid!");
            if (bankPin > 9999) throw new ArgumentNullException("Bank pin is 4 digit code!");

            try
            {
                var newPassword = bankPin.ToString();
                return newPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
