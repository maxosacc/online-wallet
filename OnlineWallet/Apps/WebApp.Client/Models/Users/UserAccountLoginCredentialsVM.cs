using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.Models
{
    public class UserAccountLoginCredentialsVM
    {
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string BankPin { get; set; }
        public UserAccountLoginCredentialsVM()
        {

        }
    }
}
