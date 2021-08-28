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
    public class ProductsController : BaseController
    {
        private readonly BL bl;
        public ProductsController()
        {
            bl = new BL(Util.ShareConnectionString.Value);
        }
        public IActionResult Productlist()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Addproduct()
        {
            return PartialView("_Productspartial");
        }
    }
}
