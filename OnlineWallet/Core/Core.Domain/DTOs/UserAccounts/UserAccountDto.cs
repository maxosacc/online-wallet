using Core.Domain.DTOs.Wallets;
using Core.Domain.Entities;
using Core.Domain.Entities.Enums;

namespace Core.Domain.DTOs.UserAccounts
{
    public class UserAccountDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public BankType Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public WalletDto Wallet { get; set; }

        public UserAccountDto()
        {

        }
        public UserAccountDto(UserAccount userAccount)
        {
            Id = userAccount.Id;
            FirstName = userAccount.FirstName;
            LastName = userAccount.LastName;
            IdentificationNumber = userAccount.IdentificationNumber;
            Bank = userAccount.Bank;
            BankAccountNumber = userAccount.BankAccountNumber;
            Password = userAccount.Password;
            IsBlocked = userAccount.IsBlocked;
            Wallet = new WalletDto(userAccount.Wallet);
        }
    }

    public static class UserAccountExtension
    {
        public static UserAccount ToDomainEntity(this UserAccountDto dto)
        {
            return new UserAccount(
                dto.FirstName,
                dto.LastName,
                dto.IdentificationNumber,
                dto.Bank,
                dto.BankAccountNumber,
                dto.Password);
        }
        public static UserAccountDto ToDto(this UserAccount userAccount)
        {
            return new UserAccountDto(userAccount);
        }
    }
}
