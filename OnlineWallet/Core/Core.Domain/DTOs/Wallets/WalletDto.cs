using Core.Domain.Entities.Wallets;
using System;

namespace Core.Domain.DTOs.Wallets
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public WalletDto(Wallet wallet)
        {
            Id = wallet.Id;
            CreatedDate = wallet.CreatedDate;
            Balance = wallet.Balance;
        }
    }
}
