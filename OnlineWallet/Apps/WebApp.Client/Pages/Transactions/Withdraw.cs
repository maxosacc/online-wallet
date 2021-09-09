using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Client.Models.Transactions;

namespace WebApp.Client.Pages.Transactions
{
    public partial class Withdraw
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        public WithdrawTransactionVM Input { get; set; } = new WithdrawTransactionVM();
        private readonly ILogger<Withdraw> Logger;

        protected override async Task OnInitializedAsync()
        {
            //Balance = 0;
            //IsAccBalanceSet = false;
        }

        public async Task LoginCheck()
        {
            try
            {
                //Balance = await _userAccountService.GetUserAccountBalance(Input.IdentificationNumber, Input.BankPin);
                //IsAccBalanceSet = true;

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
