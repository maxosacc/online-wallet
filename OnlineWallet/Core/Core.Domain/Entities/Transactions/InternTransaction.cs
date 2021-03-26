using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities.Transactions
{
    public class InternTransaction : Transaction
    {
        /// <summary>
        /// Racun sa koga je uplaceno
        /// </summary>
        public UserAccount RequestBankAccount { get; private set; }
        public InternTransaction(UserAccount requestBankAccount, decimal amount, TransactionType transactionType) : base(amount, transactionType)
        {
            RequestBankAccount = requestBankAccount;
        }
    }
}
