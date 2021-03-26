namespace Core.Domain.Entities.Transactions
{
    public class TransferTransaction : Transaction
    {
        /// <summary>
        /// Racun sa koga je uplaceno
        /// </summary>
        public UserAccount RequestBankAccount { get; private set; }
        /// <summary>
        /// Racun na koji je uplaceno
        /// </summary>
        public UserAccount RecieverBankAccount { get; private set; }

        public TransferTransaction(UserAccount requestBankAccount, UserAccount recieverBankAccount, decimal amount, TransactionType transactionType) : base(amount, transactionType)
        {
            RequestBankAccount = requestBankAccount;
            RecieverBankAccount = recieverBankAccount;
        }
    }
}
