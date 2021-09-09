using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Domain.Services.Transactions.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Client.Models;
using WebApp.Client.Models.Transactions;

namespace WebApp.Client.Pages.Transactions
{
    public partial class TransactionsOverview
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        [Inject]
        public ITransactionService _transactionService { get; set; }
        public UserAccountLoginCredentialsVM Input { get; set; } = new UserAccountLoginCredentialsVM();
        public List<TransactionVM> Transactions { get; set; } = new List<TransactionVM>();

        private readonly ILogger<TransactionsOverview> Logger;

        //protected override async Task OnInitializedAsync()
        //{
        //    //Balance = 0;
        //    //IsAccBalanceSet = false;
        //}
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
