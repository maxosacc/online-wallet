using Core.Domain.Entities.Enums;
using Core.Domain.Entities.Wallets;
using Core.Domain.Exceptions;
using System;

namespace Core.Domain.Entities
{
    public class UserAccount
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; private set; }
        public BankType Bank { get; private set; }
        public string BankAccountNumber { get; private set; }
        public string Password { get; private set; }
        public bool IsBlocked { get; private set; }
        public Wallet Wallet { get; set; }
        public DateTime CreatedDate { get; private set; }

        public UserAccount()
        {
            Wallet wallet = new Wallet();
        }
        public UserAccount(
            string firstName,
            string lastName,
            string identificationNumber,
            BankType bank,
            string bankAccountNumber,
            string password)
        {
            if (string.IsNullOrEmpty(identificationNumber)) throw new ArgumentNullException("identification number can not be null!");
            if (string.IsNullOrEmpty(bankAccountNumber)) throw new ArgumentNullException("bank account number can not be null!");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password can not be null!");
            if (password.Length > 6) throw new ArgumentNullException("password not valid. Enter max 6 numbers!");
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            Bank = bank;
            BankAccountNumber = bankAccountNumber;
            Password = password.Trim();
            CreatedDate = DateTime.UtcNow;
        }

        public void BlockUser()
        {
            if (IsBlocked)
            {
                throw new NotValidActionException("User is already blocked");
            }
            IsBlocked = true;
        }
        public void UnBlockUser()
        {
            if (!IsBlocked)
            {
                throw new NotValidActionException("User is already blocked");
            }
            IsBlocked = false;
        }
        public void PayIn(decimal amount)
        {
            Wallet.PayIn(amount);
        }

        public void PayOut(decimal amount)
        {
            Wallet.PayOut(amount);
        }
        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (!(Password == oldPassword.Trim())) throw new NotValidActionException("Old password wrong!");
            Password = newPassword;
        }

        public bool IsFirstSevenDaysOfCreation()
        {
            DateTime CreatedDatePlusSevenDays = CreatedDate.AddDays(7);
            if (DateTime.UtcNow > CreatedDatePlusSevenDays) return false;
            return true;
        }
    }
}
