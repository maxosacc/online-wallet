using Core.Domain.Entities.Enums;

namespace Core.Domain.Services
{
    public interface IUserAccountService
    {
        public int CreateUser(
            string firstName,
            string lastName,
            string userIdentificationNumber,
            BankType bankType,
            string bankAccountNumber,
            int bankPin);

        public int LoginUser(string userIdentificationNumber, string password);
        public int LogOut();

        public bool ChangePassword(string oldPassword, string newPassword);
    }
}
