using DBL;
using DBL.Helpers;
using DBL.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trippleel.Models;

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
        #region Loginuser
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Loginviewmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var resp = await bl.Login(model.Emailaddress, model.Password);
                if (resp.RespStatus == 0)
                {
                    UserModel User = new UserModel();

                    User.Staffcode = resp.Staffcode;
                    User.PhoneNo = resp.PhoneNo;
                    User.Email = resp.Email;
                    User.Fullname = resp.Fullname;
                    User.profilecode = resp.profilecode;
                    SetUserLoggedIn(User, false);
                    return RedirectToLocal(returnUrl);

                }
                else if (resp.RespStatus == 1)
                {
                    Danger(resp.RespMessage, true);
                }
                else
                {
                    Danger("Database Error Occured. Contact Admin!", true);
                }
            }
            return View(new Loginviewmodel());
        }

        private async void SetUserLoggedIn(UserModel user, bool rememberMe)
        {
            UserDataModel serializeModel = new UserDataModel
            {
                Staffcode = user.Staffcode,
                Fullname = user.Fullname,
                UserName = user.Email,
                Phonenumber = user.PhoneNo,
                ProfileCode = user.profilecode
            };

            string userData = JsonConvert.SerializeObject(serializeModel);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Staffcode.ToString()),
                new Claim(ClaimTypes.Name, user.Fullname),
                 new Claim("FullNames", serializeModel.Fullname),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Dashboard), "Home");
            }
        }
        #endregion
        #region Logout User
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion
        public IActionResult Register()
        {
            return View();
        }
    }
}
