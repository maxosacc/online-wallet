using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Pages.UserAccount
{
    public partial class Register
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public UserAccountVM Input { get; set; } = new UserAccountVM();
        private readonly ILogger<Register> Logger;
        protected override async Task OnInitializedAsync()
        {
            return;
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                var result = await _userAccountService.CreateUser(Input.FirstName, Input.LastName, Input.IdentificationNumber, Input.Bank, Input.BankAccountNumber, int.Parse( Input.BankPin));
                //--> odavde ide redirekcija sa postavljenim pass-om na ChangePass sa userAcc modelom i setovanim passom!
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
