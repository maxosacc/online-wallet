using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Client.Models.Transactions;

namespace WebApp.Client.Pages.Transactions
{
    public partial class Deposit
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        public DepositTransactionVM Input { get; set; } = new DepositTransactionVM();
        private readonly ILogger<Deposit> Logger;

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
