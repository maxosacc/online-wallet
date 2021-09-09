using Common.Utils;
using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Repositories;
using Core.Domain.Services.Banks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Services.UserAccount.Implementations
{
    public class UserAccountService : IUserAccountService
    {//TODO: dodati implementaciju
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        private readonly IBankService _bankService;
        private readonly IConfiguration _configuration;

        public UserAccountService(
            ICoreUnitOfWork coreUnitOfWork,
            IBankService bankService,
            IConfiguration configuration)
        {
            _coreUnitOfWork = coreUnitOfWork;
            _bankService = bankService;
            _configuration = configuration;
        }

        public async Task<bool> ChangePassword(string userIdentificationNumber, string oldPassword, string newPassword, string newPasswordRepeated)
        {
            var userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim() && userAcc.Password == oldPassword);
            if (userAccount != null) throw new NotValidActionException($"User account with user identity: { userIdentificationNumber } already exists.");
            if (newPassword != newPasswordRepeated) throw new NotValidParameterException("Fail! New password and repeated password are not same!");
            userAccount.ChangePassword(oldPassword,newPassword);

            await _coreUnitOfWork.UserAccountRepository.Update(userAccount);
            await _coreUnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<UserAccountDto> CreateUser(string firstName, string lastName, string userIdentificationNumber, BankType bankType, string bankAccountNumber, int bankPin)
        {
            var userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim());
            if (userAccount != null) throw new NotValidActionException($"User account with user identity: { userIdentificationNumber } already exists.");

            if (!UserIdentificationValidationHelper.MaturityValidateIdentificationNumber(userIdentificationNumber)) throw new NotValidParameterException("identification number not valid");
            var newPassword = await _bankService.ValidateUserBankAccountAndGeneratePassword(userIdentificationNumber, bankAccountNumber, bankPin);

            Entities.UserAccount u = new Entities.UserAccount(firstName, lastName, userIdentificationNumber, bankType, bankAccountNumber, newPassword);

            await _coreUnitOfWork.UserAccountRepository.Insert(u);
            await _coreUnitOfWork.SaveChangesAsync();
            return u.ToDto();
        }

        public async Task<decimal> GetUserAccountBalance(string userIdentificationNumber, string bankPin)
        {
            Entities.UserAccount userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim());

            if (userAccount == null) throw new NotValidActionException($"Wrong identification number or password! Please register if you are not!");
            var isUserValidatedInBank = await _bankService.CheckStatus(userIdentificationNumber, int.Parse(bankPin));
            if (!isUserValidatedInBank) throw new NotValidActionException($"Wrong bankPin or userIdentification. Not in Bank database.");
            return userAccount.Wallet.Balance;
        }

        public async Task<bool> LoginAsAdmin(string password)
        {
            string adminPass = _configuration["Admin:password"];
            if (password.Trim() != adminPass)
            {
                throw new NotValidActionException("Wrong admin password");
            }
            return true;
        }

        public async Task<List<UserAccountDto>> GetAllUsers(string adminPassword)
        {
            LoginAsAdmin(adminPassword).GetAwaiter().GetResult();

            var userAccounts = (await _coreUnitOfWork.UserAccountRepository.GetAllList()).ToList();
            var userAccountDtos = new List<UserAccountDto>();
            userAccounts.ForEach(u => userAccountDtos.Add(new UserAccountDto(u)));
            return userAccountDtos;
        }

        public async Task<bool> BlockUser(string adminPassword, int userId)
        {
            LoginAsAdmin(adminPassword).GetAwaiter().GetResult();
            Entities.UserAccount userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.Id == userId);
            userAccount.BlockUser();
            await _coreUnitOfWork.UserAccountRepository.Update(userAccount);
            await _coreUnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnBlockUser(string adminPassword, int userId)
        {
            LoginAsAdmin(adminPassword).GetAwaiter().GetResult();
            Entities.UserAccount userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.Id == userId);
            userAccount.UnBlockUser();
            await _coreUnitOfWork.UserAccountRepository.Update(userAccount);
            await _coreUnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
