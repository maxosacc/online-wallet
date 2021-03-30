using Core.Domain.Entities.Enums;
using Core.Domain.Repositories;
using Core.Domain.Services;
using System;

namespace Core.ApplicationServices
{
    public class UserAccountService : IUserAccountService
    {//TODO: dodati implementaciju
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        public UserAccountService(ICoreUnitOfWork coreUnitOfWork)
        {
            _coreUnitOfWork = coreUnitOfWork;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(string firstName, string lastName, string userIdentificationNumber, BankType bankType, string bankAccountNumber, int bankPin)
        {
            throw new NotImplementedException();
        }

        public int LoginUser(string userIdentificationNumber, string password)
        {
            throw new NotImplementedException();
        }

        public int LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
