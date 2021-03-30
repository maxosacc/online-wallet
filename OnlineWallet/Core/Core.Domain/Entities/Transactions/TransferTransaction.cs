namespace Core.Domain.Entities.Transactions
{
    public class TransferTransaction : Transaction
    {
        /// <summary>
        /// Racun na koji je uplaceno
        /// </summary>
        public UserAccount RecieverBankAccount { get; private set; }

        public TransferTransaction() : base()
        {

        }
        public TransferTransaction(UserAccount requestBankAccount, UserAccount recieverBankAccount, decimal amount, TransactionType transactionType) : base(amount, transactionType, requestBankAccount)
        {
            RecieverBankAccount = recieverBankAccount;
        }
    }
}
