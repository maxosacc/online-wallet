using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.UserAccount
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
