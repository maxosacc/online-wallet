using System.ComponentModel.DataAnnotations;

namespace WebAppServer.Models.UserAccount
{
    public class UserAccountChangePassVM
    {
        public int Id { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string RepeatedNewPassword { get; set; }
    }
}
