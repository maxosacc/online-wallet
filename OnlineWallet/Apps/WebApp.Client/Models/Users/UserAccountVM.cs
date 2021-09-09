using Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Client.Models
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
        public string BankPin { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdmin { get; set; }

        public UserAccountVM()
        {

        }
    }
}
