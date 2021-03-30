using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Services.Banks
{
    public interface IBankService
    {
        public int ValidateUserAccountBankAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin);
        public bool CheckStatus(string userIdentificationNumber, int bankPin);
        public bool Deposit(string userIdentificationNumber, int bankPin, decimal amount);
        public bool Withdraw(string userIdentificationNumber, int bankPin, decimal amount);
    }
}
