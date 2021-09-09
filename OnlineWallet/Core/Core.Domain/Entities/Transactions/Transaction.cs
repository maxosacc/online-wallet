using Core.Domain.Entities.Transactions.Enums;
using System;

namespace Core.Domain.Entities.Transactions
{
    public class Transaction
    {
        public int Id { get; private set; }
        /// <summary>
        /// Svota
        /// </summary>
        public decimal Amount { get; private set; }
        /// <summary>
        /// Datum i vreme transakcije
        /// </summary>
        public DateTime TransactionDateTime { get; private set; }
        /// <summary>
        /// Tip transakcije
        /// </summary>
        public TransactionType Type { get; private set; }
        /// <summary>
        /// Tip zahtjeva transakcije: Interna, Transfer i BankFee.
        /// </summary>
        public TransactionRequestType TransactionRequestType { get; private set; }
        /// <summary>
        /// Racun sa koga je uplaceno
        /// </summary>
        public UserAccount FromBankAccount { get; private set; }
        /// <summary>
        /// Racun na koji je uplaceno
        /// </summary>
        public UserAccount? ToBankAccount { get; private set; }

        public Transaction()
        {

        }

        public Transaction(decimal amount, TransactionType transactionType, TransactionRequestType transactionRequestType, UserAccount requestBankAccount, UserAccount recieverBankAccount = null)
        {
            Amount = amount;
            TransactionDateTime = DateTime.Now;
            Type = transactionType;
            TransactionRequestType = transactionRequestType;
            FromBankAccount = requestBankAccount;
            ToBankAccount = recieverBankAccount;
        }
    }
}
