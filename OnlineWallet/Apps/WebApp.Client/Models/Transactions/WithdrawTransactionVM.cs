using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.Models.Transactions
{
    public class WithdrawTransactionVM
    {
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string BankPin { get; set; }

        public decimal Amount { get; set; } = 0.00M;

        public WithdrawTransactionVM()
        {

        }
    }
}
