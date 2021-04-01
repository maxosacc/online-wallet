using Core.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.UserAccount
{
    public class UserAccountVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public BankType Bank { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }
        [Required]
        public int BankPin { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdmin { get; set; }

        public UserAccountVM()
        {

        }
    }
}
