using DBL;
using DBL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Controllers
{
    [Authorize]
    public class AccountsController : BaseController
    {
        private readonly BL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public AccountsController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
