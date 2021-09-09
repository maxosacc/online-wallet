using System.ComponentModel.DataAnnotations;

namespace WebApp.Client.Models
{
    public class UserAccountChangePasswordVM
    {
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string NewPasswordRepeated { get; set; }
        public UserAccountChangePasswordVM()
        {

        }
    }
}
