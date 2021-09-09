using Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Entities.Wallets
{
    public class Wallet
    {
        public int Id { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public Wallet()
        {
            CreatedDate = DateTime.UtcNow;
            Balance = 0;
        }

        public void PayIn(decimal amount)
        {
            Balance += amount;
        }
        public void PayOut(decimal amount)
        {
            if ((Balance - amount) < 0) throw new NotValidActionException("Not enough cash on your account");
            Balance -= amount;
        }
    }
}
