namespace Core.Domain.Entities.Transactions
{
    public class FeeTransaction : Transaction
    {
        public FeeTransaction() : base()
        {

        }
        public FeeTransaction(UserAccount requestBankAccount, decimal amount) : base(amount, TransactionType.PayOut, requestBankAccount)
        {
        }
    }
}
