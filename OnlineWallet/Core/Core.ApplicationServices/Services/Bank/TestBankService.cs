using Core.Domain.Exceptions;
using Core.Domain.Services.Banks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.ApplicationServices.Services.Bank
{
    public class TestBankService : IBankService
    {
        public TestBankService()
        {
        }
        public Task<bool> CheckStatus(string userIdentificationNumber, int bankPin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deposit(string userIdentificationNumber, int bankPin, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Withdraw(string userIdentificationNumber, int bankPin, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ValidateUserBankAccountAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin)
        {
            if (bankPin <= 0) throw new ArgumentNullException("Bank pin is not valid!");
            if (bankPin > 9999) throw new ArgumentNullException("Bank pin is 4 digit code!");

            //http call to BankAPI to check status and another to validate user
            bool isAPIActive = await CheckBankServiceStatus();
            if (!isAPIActive) throw new BankAPINotRespondingException("XomaBank is not responding!");

            //http call to BankAPI to validate user
            try
            {
                var newPassword = await ValidateBankAccountAndGeneratePassword();
                return newPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> CheckBankServiceStatus()
        {
            return true;
        }

        private async Task<string> ValidateBankAccountAndGeneratePassword()
        {
            try
            {
                var responseContent = "1234";
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
