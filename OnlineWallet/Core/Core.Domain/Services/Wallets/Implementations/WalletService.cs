using Core.Domain.Entities.Transactions;
using Core.Domain.Entities.Transactions.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Repositories;
using Core.Domain.Services.Banks;
using Core.Domain.Services.Wallets.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Core.Domain.Services.Wallets.Implementations
{
    public class WalletService : IWalletService
    {
        private readonly ICoreUnitOfWork _coreUnitOfWork;
        private readonly IBankService _bankService;
        private readonly IConfiguration _configuration;

        public WalletService(
            ICoreUnitOfWork coreUnitOfWork, 
            IBankService bankService,
            IConfiguration configuration)
        {
            _coreUnitOfWork = coreUnitOfWork;
            _bankService = bankService;
            _configuration = configuration;
        }
        public async Task<string> Deposit(string userIdentificationNumber, string password, int bankPin, string bankAccountNumber, decimal amount)
        {
            Entities.UserAccount loggedInUser = await IsUserAuthenticated(userIdentificationNumber, password, bankPin);
            await _bankService.CheckStatus(userIdentificationNumber, bankPin);
            try
            {
                await _coreUnitOfWork.BeginTransactionAsync();
                //pozvati bank api da odradi prenos
                var result = await _bankService.Withdraw(userIdentificationNumber, bankPin, amount);
                if (!result) throw new NotValidActionException("couldnt withdraw funds from bank. Try again later");

                loggedInUser.PayIn(amount);
                Transaction newTransaction = new Transaction(amount, TransactionType.PayIn, TransactionRequestType.Internal, loggedInUser);
                await _coreUnitOfWork.TransactionRepository.Insert(newTransaction);
                await _coreUnitOfWork.SaveChangesAsync();
                await _coreUnitOfWork.CommitTransactionAsync();
                return userIdentificationNumber;//todo izmeni
            }
            catch (Exception)
            {
                await _coreUnitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<string> Withdraw(string userIdentificationNumber, string password, int bankPin, string bankAccountNumber, decimal amount)
        {
            Entities.UserAccount loggedInUser = await IsUserAuthenticated(userIdentificationNumber, password, bankPin);
            
            try
            {
                await _coreUnitOfWork.BeginTransactionAsync();
                //pozvati bank api da odradi prenos payin
                loggedInUser.PayOut(amount);
                Transaction newTransaction = new Transaction(amount, TransactionType.PayOut, TransactionRequestType.Internal, loggedInUser);
                await _coreUnitOfWork.TransactionRepository.Insert(newTransaction);
                await _coreUnitOfWork.SaveChangesAsync();
                await _coreUnitOfWork.CommitTransactionAsync();
                return userIdentificationNumber;//todo izmeni
            }
            catch (Exception)
            {
                await _coreUnitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<string> Transfer(string userIdentificationNumber, string password, int bankPin, string userFromBankAccountNumber, string userToBankAccountNumber, decimal amount)
        {
            // Prilikom transfera novca za iznose do 10.000 din posiljaocu se naplacuje fiksna nakanada od 100 din, 
            //za iznose od 10.000 dinara pa na vise naplacuje se provizija u iznosu od 1% od iznosa za transfer.
            //Prvih sedam dana nakon kreiranja novcanika ne naplacuje se provizija na transfer
            //ovo iz config-a
            var loggedInUser = await IsUserAuthenticated(userIdentificationNumber, password, bankPin);
            decimal amountWithFee = amount;
            if(!loggedInUser.IsFirstSevenDaysOfCreation())
            {
                amountWithFee = CalculateFee(amount);
            }
            // provera da li drugi user postoji ili je blokiran
            Entities.UserAccount recieverUserAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim() && userAcc.Password == password);
            if (recieverUserAccount.IsBlocked) throw new NotValidActionException($"Invalid action. User with {userIdentificationNumber} is blocked!");

            await _bankService.CheckStatus(userIdentificationNumber,bankPin);
            try
            {
                await _coreUnitOfWork.BeginTransactionAsync();
                await _bankService.Transfer(loggedInUser.IdentificationNumber, bankPin, amountWithFee, recieverUserAccount.BankAccountNumber);
                //isplata sa racuna
                loggedInUser.PayOut(amount);
                Transaction payOutTransferTransaction = new Transaction(amountWithFee, TransactionType.PayOut, TransactionRequestType.Transfer, loggedInUser, recieverUserAccount);

                //uplata na racun
                recieverUserAccount.PayIn(amount);
                Transaction payInTransferTransaction = new Transaction(amountWithFee, TransactionType.PayIn, TransactionRequestType.Transfer, recieverUserAccount, loggedInUser);

                await _coreUnitOfWork.TransactionRepository.Insert(payOutTransferTransaction);
                await _coreUnitOfWork.SaveChangesAsync();
                await _coreUnitOfWork.TransactionRepository.Insert(payInTransferTransaction);
                await _coreUnitOfWork.SaveChangesAsync();
                await _coreUnitOfWork.CommitTransactionAsync();
                return userIdentificationNumber;//todo izmeni
            }
            catch (Exception)
            {
                await _coreUnitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
        private async Task<Entities.UserAccount> IsUserAuthenticated(string userIdentificationNumber, string password, int bankPin)
        {
            Entities.UserAccount userAccount = await _coreUnitOfWork.UserAccountRepository.GetFirstOrDefaultWithIncludes(userAcc => userAcc.IdentificationNumber == userIdentificationNumber.Trim() && userAcc.Password == password);
            if (userAccount == null) throw new NotValidActionException($"Wrong identification number or password! Please register if you are not!");
            // provera da li je user blokiran
            if (userAccount.IsBlocked) throw new NotValidActionException($"Invalid action. User with {userIdentificationNumber} is blocked!");
            var isUserValidatedInBank = await _bankService.CheckStatus(userIdentificationNumber, bankPin);
            if (!isUserValidatedInBank) throw new NotValidActionException($"Wrong bankPin or userIdentification. Not in Bank database.");
            return userAccount;
        }

        private decimal CalculateFee(decimal amount)
        {
            int fixedFee = int.Parse( _configuration["Fee:FixedFeeInInteger"]);
            int percentageFee = int.Parse(_configuration["Fee:DynamicFeeInPercantage"]);
            long minAmountForDynamicFee = int.Parse(_configuration["Fee:MinAmountForDynamicFee"]);

            if(amount > minAmountForDynamicFee)
            {
                decimal decimalValueOfAmountPercentage = (percentageFee / 100.0M)*amount;
                amount += decimalValueOfAmountPercentage;
                return amount;
            }
            else
            {
                return amount + fixedFee;
            }
        }
    }
}
