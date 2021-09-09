using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Client.Models.Transactions
{
    public class DepositTransactionVM
    {
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string BankPin { get; set; }

        public decimal Amount { get; set; } = 0.00M;
        public DepositTransactionVM()
        {

        }
    }
}
