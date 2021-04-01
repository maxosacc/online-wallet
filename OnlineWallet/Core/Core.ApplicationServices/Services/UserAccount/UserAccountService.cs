using Common.Utils;
using Core.Domain.DTOs.UserAccounts;
using Core.Domain.Entities;
using Core.Domain.Entities.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Repositories;
using Core.Domain.Services;
using Core.Domain.Services.Banks;
using System;
using System.Threading.Tasks;

namespace Core.ApplicationServices
{
    public class UserAccountService : IUserAccountService
    {//TODO: dodati implementaciju
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        private readonly IBankService _bankService;
        public UserAccountService(
            ICoreUnitOfWork coreUnitOfWork,
            IBankService bankService)
        {
            _coreUnitOfWork = coreUnitOfWork;
            _bankService = bankService;
        }

        public Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccountDto> CreateUser(string firstName, string lastName, string userIdentificationNumber, BankType bankType, string bankAccountNumber, int bankPin)
        {
            var userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim());
            if (userAccount != null) throw new NotValidActionException($"User account with user identity: { userIdentificationNumber } already exists.");

            if (!UserIdentificationValidationHelper.MaturityValidateIdentificationNumber(userIdentificationNumber)) throw new NotValidParameterException("identification number not valid");
            var newPassword = await _bankService.ValidateUserBankAccountAndGeneratePassword(userIdentificationNumber, bankAccountNumber, bankPin);

            UserAccount u = new UserAccount(firstName, lastName, userIdentificationNumber, bankType, bankAccountNumber, newPassword, false);

            await _coreUnitOfWork.UserAccountRepository.Insert(u);
            await _coreUnitOfWork.SaveChangesAsync();
            return u.ToDto();
        }

        public Task<int> LoginUser(string userIdentificationNumber, string password)
        {
            throw new NotImplementedException();
        }

        public Task<int> LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccountDto> CreateUserTestMock(string firstName, string lastName, string userIdentificationNumber, BankType bankType, string bankAccountNumber, int bankPin)
        {
            var newPassword = await _bankService.ValidateUserBankAccountAndGeneratePasswordTestMock(userIdentificationNumber, bankAccountNumber, bankPin);

            UserAccount u = new UserAccount(firstName, lastName, userIdentificationNumber, bankType, bankAccountNumber, newPassword, false);

            await _coreUnitOfWork.UserAccountRepository.Insert(u);
            await _coreUnitOfWork.SaveChangesAsync();
            return u.ToDto();
        }
    }
}
