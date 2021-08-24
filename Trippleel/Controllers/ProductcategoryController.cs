using DBL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Controllers
{
    public class ProductcategoryController : BaseController
    {
        private readonly BL bl;
        //EncryptDecrypt sec = new EncryptDecrypt();
        public ProductcategoryController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        public IActionResult Productcategorylist()
        {
            return View();
        }
    }
}
