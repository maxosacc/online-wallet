using Core.Domain.DTOs.Transactions;
using Core.Domain.DTOs.UserAccounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : Controller
    {
        private readonly ILogger<BankAccountController> _logger;
        private readonly List<UserAccountBankParamsDto> _bankAccounts;
        private readonly IConfiguration _config;
        public BankAccountController(ILogger<BankAccountController> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _bankAccounts = new List<UserAccountBankParamsDto>();
            InitializeBankAccounts();
        }
        [HttpPost]
        [Route("ValidateUserAndGetPassword")]
        public IActionResult ValidateUserAndGetPassword([FromBody] UserAccountBankParamsDto userAccountProperties)
        {
            if (!ValidateBankAccount(userAccountProperties.UserIdentificationNumber, userAccountProperties.BankAccountNumber, userAccountProperties.Pin)) return BadRequest("Bank account number does not exist! wrong user identification number or password");
            string newPassword = GenerateSixDigitPassword().ToString();
            _logger.LogInformation("User validated and generated new password.");
            return Ok(newPassword);
        }
        [HttpPost]
        [Route("ValidateUser")]
        public IActionResult ValidateUser([FromBody] UserAccountBankParamsDto userAccountProperties)
        {
            if (!ValidateBankAccount(userAccountProperties.UserIdentificationNumber, userAccountProperties.BankAccountNumber, userAccountProperties.Pin)) return BadRequest("Bank account number does not exist! wrong user identification number or password");
            return Ok();
        }

        [HttpPost]
        [Route("Deposit")]
        public IActionResult Deposit([FromBody] TransactionBankParamsDto transactionBankParams)
        {
            if (!ValidateBankAccount(transactionBankParams.UserIdentificationNumber, transactionBankParams.BankAccountNumber, transactionBankParams.Pin)) return BadRequest("Bank account number does not exist! wrong user identification number or password");
            
            foreach(var bankAcc in _bankAccounts)
            {
                if(bankAcc.UserIdentificationNumber == transactionBankParams.UserIdentificationNumber)
                {
                    bankAcc.Balance += transactionBankParams.Amount;
                    return Ok(bankAcc.Balance);
                }
            }
            return BadRequest("didnt found any bankAcc");
        }
        [HttpPost]
        [Route("Withdraw")]
        public IActionResult Withdraw([FromBody] TransactionBankParamsDto transactionBankParams)
        {
            if (!ValidateBankAccount(transactionBankParams.UserIdentificationNumber, transactionBankParams.BankAccountNumber, transactionBankParams.Pin)) return BadRequest("Bank account number does not exist! wrong user identification number or password");
            foreach (var bankAcc in _bankAccounts)
            {
                if (bankAcc.UserIdentificationNumber == transactionBankParams.UserIdentificationNumber)
                {
                    if (bankAcc.Balance - transactionBankParams.Amount < 0) return BadRequest("Not enough funds");
                    bankAcc.Balance -= transactionBankParams.Amount;
                    return Ok(bankAcc.Balance);
                }
            }
            return BadRequest("didnt found any bankAcc");
        }
        [HttpPost]
        [Route("Transfer")]
        public IActionResult Transfer([FromBody] TransactionBankParamsDto transactionBankParams)
        {
            if (!ValidateBankAccount(transactionBankParams.UserIdentificationNumber, transactionBankParams.BankAccountNumber, transactionBankParams.Pin)) return BadRequest("Bank account number does not exist! wrong user identification number or password");
            UserAccountBankParamsDto recieverBankAccExist = _bankAccounts.FirstOrDefault(bankAccount => bankAccount.BankAccountNumber == transactionBankParams.RecieverBankAccountNumber);
            if (recieverBankAccExist == null) return BadRequest("reciever bank account does not exist");

            foreach (var bankAcc in _bankAccounts)
            {
                if (bankAcc.UserIdentificationNumber == transactionBankParams.UserIdentificationNumber)
                {
                    if (bankAcc.Balance - transactionBankParams.Amount < 0) return BadRequest("Not enough funds");
                    bankAcc.Balance -= transactionBankParams.Amount;
                }
            }
            
            _bankAccounts.ForEach(bankAcc => 
            { 
                if(bankAcc.BankAccountNumber== transactionBankParams.BankAccountNumber)
                {
                    bankAcc.Balance += transactionBankParams.Amount;
                }   
            });
            return Ok(transactionBankParams.Amount);
        }

        private int GenerateSixDigitPassword()
        {
            int number = new Random().Next(100000, 999999);
            _logger.LogInformation("generated six digit password.");
            return number;
        }
        private bool ValidateBankAccount(string userIdentificationNumber, string bankAccountNumber, string pin)
        {
            UserAccountBankParamsDto bankAccount = _bankAccounts.FirstOrDefault(bankAccount => bankAccount.UserIdentificationNumber == userIdentificationNumber && bankAccount.Pin == pin);
            if (bankAccount != null) return true;
            return false;
        }
        private void InitializeBankAccounts()
        {
            var user1 = new UserAccountBankParamsDto(_config["BankAccounts:Acc1:uid"], _config["BankAccounts:Acc1:BankAccNum"], _config["BankAccounts:Acc1:pin"]);
            var user2 = new UserAccountBankParamsDto(_config["BankAccounts:Acc2:uid"], _config["BankAccounts:Acc2:BankAccNum"], _config["BankAccounts:Acc2:pin"]);
            var user3 = new UserAccountBankParamsDto(_config["BankAccounts:Acc3:uid"], _config["BankAccounts:Acc3:BankAccNum"], _config["BankAccounts:Acc3:pin"]);
            var user4 = new UserAccountBankParamsDto(_config["BankAccounts:Acc4:uid"], _config["BankAccounts:Acc4:BankAccNum"], _config["BankAccounts:Acc4:pin"]);
            _bankAccounts.Add(user1);
            _bankAccounts.Add(user2);
            _bankAccounts.Add(user3);
            _bankAccounts.Add(user4);
        }
    }
}
