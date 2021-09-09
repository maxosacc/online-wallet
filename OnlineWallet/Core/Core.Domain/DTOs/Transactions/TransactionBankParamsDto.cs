namespace Core.Domain.DTOs.Transactions
{
    public class TransactionBankParamsDto
    {
        public string UserIdentificationNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string RecieverBankAccountNumber { get; set; }
        public string Pin { get; set; }
        public decimal Amount { get; set; }
    }
}
