namespace Core.Domain.Entities.Transactions
{
    public class FeeTransaction : Transaction
    {
        /// <summary>
        /// Racun sa koga je uplaceno
        /// </summary>
        public UserAccount RequestBankAccount { get; private set; }
        public FeeTransaction() : base()
        {

        }
        public FeeTransaction(UserAccount requestBankAccount, decimal amount) : base(amount, TransactionType.PayOut)
        {
            RequestBankAccount = requestBankAccount;
        }
    }
}
