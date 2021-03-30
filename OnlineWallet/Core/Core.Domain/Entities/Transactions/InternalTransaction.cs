namespace Core.Domain.Entities.Transactions
{
    public class InternalTransaction : Transaction
    {
        public InternalTransaction() : base()
        {

        }
        public InternalTransaction(UserAccount requestBankAccount, decimal amount, TransactionType transactionType) : base(amount, transactionType, requestBankAccount)
        {
        }
    }
}
