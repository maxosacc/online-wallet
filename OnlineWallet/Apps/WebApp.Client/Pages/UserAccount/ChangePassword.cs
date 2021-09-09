using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Pages.UserAccount
{
    public partial class ChangePassword
    {

        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        public UserAccountChangePasswordVM Input { get; set; } = new UserAccountChangePasswordVM();
        public int SelectedUserId { get; set; } = -1;

        private readonly ILogger<ChangePassword> Logger;
        public async Task LoginCheck()
        {
            try
            {
                
                await _userAccountService.ChangePassword(Input.IdentificationNumber, Input.OldPassword, Input.NewPassword, Input.NewPasswordRepeated);
            }
            catch (NotValidParameterException e)
            {
                Logger.LogError(e, e.Message);
                throw;
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
