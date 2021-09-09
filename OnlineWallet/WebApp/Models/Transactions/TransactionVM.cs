using Core.Domain.Entities.Transactions;
using Core.Domain.Entities.Transactions.Enums;
using System;

namespace WebApp.Models.Transactions
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public TransactionType Type { get; set; }
        public TransactionRequestType TransactionRequestType { get; set; }
        public Core.Domain.Entities.UserAccount RequestBankAccount { get; set; }
    }
}
