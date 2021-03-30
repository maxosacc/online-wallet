using Core.Domain.Services.Banks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices.Bank
{
    public class XomaBankService : IBankService
    {//TODO: dodati implementaciju mock-a
        public XomaBankService()
        {

        }
        public bool CheckStatus(string userIdentificationNumber, int bankPin)
        {
            throw new NotImplementedException();
        }

        public bool Deposit(string userIdentificationNumber, int bankPin, decimal amount)
        {
            throw new NotImplementedException();
        }

        public int ValidateUserAccountBankAndGeneratePassword(string userIdentificationNumber, string bankAccountNumber, int bankPin)
        {
            throw new NotImplementedException();
        }

        public bool Withdraw(string userIdentificationNumber, int bankPin, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
