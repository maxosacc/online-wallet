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
        private readonly List<string> _bankAccounts;
        private readonly IConfiguration _config;
        public BankAccountController(ILogger<BankAccountController> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            InitializeBankAccounts();
        }
        [HttpPost]
        [Route("ValidateUserAndGetPassword")]
        public IActionResult ValidateUserAndGetPassword(string bankAccountNumber)
        {
            if (!IsAlreadyExistBankAccount(bankAccountNumber)) return BadRequest("Bank account number does not exist!");
            string newPassword = GenerateSixDigitPassword().ToString();
            _logger.LogInformation("User validated and generated new password.");
            return Ok(newPassword);
        }

        private int GenerateSixDigitPassword()
        {
            int number = new Random().Next(100000, 999999);
            _logger.LogInformation("generated six digit password.");
            return number;
        }
        private bool IsAlreadyExistBankAccount(string bankAccountNumber)
        {
            string bankAccount = _bankAccounts.FirstOrDefault(bankAccount => bankAccount == bankAccountNumber);
            if (bankAccount == bankAccountNumber) return true;
            return false;
        }
        private void InitializeBankAccounts()
        {
            _bankAccounts.Add(_config["BankAccounts:Acc1"]);
            _bankAccounts.Add(_config["BankAccounts:Acc2"]);
            _bankAccounts.Add(_config["BankAccounts:Acc3"]);
            _bankAccounts.Add(_config["BankAccounts:Acc4"]);
        }
    }
}
