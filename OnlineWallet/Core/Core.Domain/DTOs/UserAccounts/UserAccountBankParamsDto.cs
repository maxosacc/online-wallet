using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.DTOs.UserAccounts
{
    public class UserAccountBankParamsDto
    {
        public string UserIdentificationNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }

        public UserAccountBankParamsDto()
        {

        }
        public UserAccountBankParamsDto(string userIdentificationNumber, string bankAccountNumber, string pin)
        {
            UserIdentificationNumber = userIdentificationNumber;
            BankAccountNumber = bankAccountNumber;
            Pin = pin;
            Balance = 0;
        }
    }
}
