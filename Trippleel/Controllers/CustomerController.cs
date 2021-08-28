using DBL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly BL bl;
        public CustomerController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        public IActionResult Customerslist()
        {
            return View();
        }
    }
}
