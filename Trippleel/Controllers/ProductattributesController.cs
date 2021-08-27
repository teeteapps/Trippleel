using DBL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trippleel.Controllers
{
    public class ProductattributesController : BaseController
    {
        private readonly BL bl;
        //EncryptDecrypt sec = new EncryptDecrypt();
        public ProductattributesController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        [HttpGet]
        public async Task<IActionResult> Productattributeslist()
        {
            var data = await bl.GetProductattributeslist();
            return View(data);
        }
    }
}
