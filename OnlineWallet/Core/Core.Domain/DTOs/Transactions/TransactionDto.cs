using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities.Transactions;
using Core.Domain.Entities.Transactions.Enums;
using System;
using System.Collections.Generic;

namespace Core.Domain.DTOs.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public TransactionType Type { get; set; }
        public TransactionRequestType TransactionRequestType { get; set; }
        public UserAccountDto RequestBankAccount { get; set; }
        public UserAccountDto RecieverBankAccount { get; set; }
        public TransactionDto(Transaction transaction)
        {
            Id = transaction.Id;
            Amount = transaction.Amount;
            TransactionDateTime = transaction.TransactionDateTime;
            Type = transaction.Type;
            TransactionRequestType = transaction.TransactionRequestType;
            RequestBankAccount = new UserAccountDto(transaction.FromBankAccount);
            RecieverBankAccount = new UserAccountDto(transaction.ToBankAccount);
        }
    }
    public static class TransactionExtension
    {
        public static TransactionDto ToDto(this Transaction transaction)
        {
            return new TransactionDto(transaction);
        }
        public static List<TransactionDto> ToDtos(this List<Transaction> transactions)
        {
            List<TransactionDto> transactionDtos = new List<TransactionDto>();
            transactions.ForEach(t => transactionDtos.Add(t.ToDto()));
            return transactionDtos;
        }
    }
}
