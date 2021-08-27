using DBL;
using DBL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Trippleel.Models;

namespace Trippleel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BL bl;
        EncryptDecrypt sec = new EncryptDecrypt();
        public HomeController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        public IActionResult Dashboard()
        {
            return View();
        } 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
