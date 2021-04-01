using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.UserAccount;

namespace WebApp.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new UserAccountVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserAccountVM user)
        {
            try
            {
                var result = await _userAccountService.CreateUser(user.FirstName, user.LastName, user.IdentificationNumber, user.Bank, user.BankAccountNumber, user.BankPin);
                //--> odavde ide redirekcija sa postavljenim pass-om na ChangePass sa userAcc modelom i setovanim passom!
                return RedirectToAction("ChangePassword",new UserAccountChangePassVM() { Id = user.Id });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new UserAccountVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserAccountVM user)
        {
            await _userAccountService.LoginUser(user.IdentificationNumber, user.Password);
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(UserAccountChangePassVM userAccountChangePassVM = null)
        {

            return View(userAccountChangePassVM == null ? new UserAccountChangePassVM() : userAccountChangePassVM);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordSubmit(UserAccountChangePassVM userAccountChangePassVM)
        {

            return null;
        }
    }
}
