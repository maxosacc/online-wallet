﻿using System;

namespace Core.Domain.Entities.Transactions
{
    public abstract class Transaction
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
        /// Racun sa koga je uplaceno
        /// </summary>
        public UserAccount RequestBankAccount { get; private set; }
        public Transaction()
        {

        }

        public Transaction(decimal amount, TransactionType transactionType, UserAccount requestBankAccount)
        {
            Amount = amount;
            TransactionDateTime = DateTime.Now;
            Type = transactionType;
            RequestBankAccount = requestBankAccount;
        }
    }
}
