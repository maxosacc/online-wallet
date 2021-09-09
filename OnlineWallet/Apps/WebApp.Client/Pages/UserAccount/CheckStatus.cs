using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Pages.UserAccount
{
    public partial class CheckStatus
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        public UserAccountLoginCredentialsVM Input { get; set; } = new UserAccountLoginCredentialsVM();
        private readonly ILogger<CheckStatus> Logger;
        public bool IsAccBalanceSet { get; set; }
        public decimal Balance { get; set; }
        private string BalanceComponentsVisibility => IsAccBalanceSet ? "visible" : "hidden";
        protected override async Task OnInitializedAsync()
        {
            Balance = 0;
            IsAccBalanceSet = false;
        }

        public async Task LoginCheck()
        {
            try
            {
                Balance = await _userAccountService.GetUserAccountBalance(Input.IdentificationNumber, Input.BankPin);
                IsAccBalanceSet = true;

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
