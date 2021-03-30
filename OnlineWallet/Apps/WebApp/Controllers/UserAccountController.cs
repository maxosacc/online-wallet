using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }
    }
}
