using DBL;
using DBL.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Controllers
{
    public class AccountController : BaseController
    {
        private readonly BL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public AccountController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
