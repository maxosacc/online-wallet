using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities;
using Core.Domain.Entities.Transactions;
using Core.Domain.Entities.Transactions.Enums;
using System;

namespace WebApp.Client.Models.Transactions
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public TransactionType Type { get; set; }
        public TransactionRequestType TransactionRequestType { get; set; }
        public UserAccountDto RequestBankAccount { get; set; }
        public UserAccountDto RecieverBankAccount { get; set; }

        public TransactionVM()
        {

        }
    }
}
