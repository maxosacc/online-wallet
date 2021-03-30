using Core.Domain.Entities.Enums;
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
        public bool IsAdmin { get; private set; }

        public UserAccount()
        {

        }
        public UserAccount(
            string firstName,
            string lastName,
            string identificationNumber,
            BankType bank,
            string bankAccountNumber,
            string password,
            bool isAdmin = false)
        {
            IsAdmin = isAdmin;
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            Bank = bank;
            BankAccountNumber = bankAccountNumber;
            Password = password;
        }

        public void BlockUser()
        {
            if (IsBlocked)
            {
                throw new NotValidActionException("User is already blocked");
            }
            IsBlocked = IsBlocked;

        }
    }
}
