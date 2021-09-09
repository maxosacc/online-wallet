using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApp.Models.UserAccount;

namespace WebApp.Controllers
{
    public class UserAccountController : Controller
    {//TODO SVE AKCIJE MORAJU PROSLEDJIVATI JMBG I PASS
        private readonly IUserAccountService _userAccountService;
        private readonly ILogger<UserAccountController> Logger;
        public UserAccountController(IUserAccountService userAccountService,ILogger<UserAccountController> logger)
        {
            _userAccountService = userAccountService;
            Logger = logger;
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
                return RedirectToAction("ChangePassword",new UserAccountChangePassVM() { Id = user.Id, IdentificationNumber = user.IdentificationNumber, OldPassword = user.Password });
            }
            catch (NotValidParameterException e)
            {
                Logger.LogError(e, e.Message);
                return RedirectToPage("Error");
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return RedirectToPage("Home/Error");
            }
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
