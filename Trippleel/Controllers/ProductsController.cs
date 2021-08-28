using DBL;
using DBL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            LoadParams();
            return PartialView("_Productspartial");
        }

        #region Other methods
        private void LoadParams()
        {
            var list = bl.GetListModel(ListModelType.productcategory).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["productcategorylists"] = list;
            list = bl.GetListModel(ListModelType.attributes).Result.Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
            ViewData["attributeslists"] = list;
        }
        #endregion
    }
}
