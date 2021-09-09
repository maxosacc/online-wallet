using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Client.Models.Transactions;

namespace WebApp.Client.Pages.Transactions
{
    public partial class Transfer
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        public TransferTransactionVM Input { get; set; } = new TransferTransactionVM();
        private readonly ILogger<Transfer> Logger;
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
