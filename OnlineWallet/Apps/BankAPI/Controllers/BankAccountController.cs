using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : Controller
    {
        private readonly ILogger<BankAccountController> _logger;
        public BankAccountController(ILogger<BankAccountController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("ValidateUserAndGetPassword")]
        public IActionResult ValidateUserAndGetPassword()
        {
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
    }
}
