using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Domain.Services.Transactions.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Pages.Admin
{
    public partial class AllUsers
    {
        [Inject]
        public IUserAccountService _userAccountService { get; set; }
        [Inject]
        public ITransactionService _transactionService { get; set; }
        public AdminUserVM Input { get; set; } = new AdminUserVM();
        public List<UserAccountDto> Users { get; set; } = new List<UserAccountDto>();
        public bool IsAdminLoggedIn { get; set; } = false;
        public int SelectedUserId { get; set; } = -1;

        private readonly ILogger<AllUsers> Logger;
        public async Task LoginCheck()
        {
            try
            {
                IsAdminLoggedIn = await _userAccountService.LoginAsAdmin(Input.AdminPassword);
                if (IsAdminLoggedIn)
                {
                    Users = await _userAccountService.GetAllUsers(Input.AdminPassword);
                }

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

        public void SelectTableRow(int id)
        {
            if (SelectedUserId == id)
            {
                SelectedUserId = -1;
            }
            else
            {
                SelectedUserId = id;
            }
        }

        public async Task Unblock(int id)
        {
            await _userAccountService.UnBlockUser(Input.AdminPassword, id);
        }
        public async Task Block(int id)
        {
            await _userAccountService.BlockUser(Input.AdminPassword, id);
        }
    }
}
