using DBL;
using DBL.Enitites;
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
        public async Task<IActionResult> Productlist()
        {
            var data = await bl.Getallproductvariations(SessionUserData.Staffcode);
            return View(data);
        }
        [HttpGet]
        public IActionResult Addproduct()
        {
            LoadParams();
            return PartialView("_Productspartial");
        }

        [HttpPost]
        public async Task<JsonResult> Addproducts(Products model)
        {

            model.Accountcode = SessionUserData.Staffcode;
            model.Createdby = SessionUserData.Staffcode;
            model.Modifiedby = SessionUserData.Staffcode;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductsdata(model);
            if (resp.RespStatus > 1)
            {
                resp.RespStatus = 2; resp.RespMessage = "Database error occured";
            }
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }
        [HttpGet]
        public IActionResult Editproductvariationfiels(long Variationcode,string Variationname,string variationvalname)
        {
            Productvariationsmodel model = new Productvariationsmodel();
            model.Productvarcode = Variationcode;
            model.Variationname = Variationname;
            model.Variationvalname = variationvalname;
            if (variationvalname == "Productdescription")
            {
                return PartialView("_Productdescriptionpartial", model);
            }
            else if (variationvalname == "Productfeatures")
            {
                return PartialView("_Productfeaturespartial", model);
            }
            else if(variationvalname == "Productspecifications")
            {
                return PartialView("_Productspecificationspartial", model);
            }else if (variationvalname == "Productwhatsinbox")
            {
                return PartialView("_Productwhatsinboxpartial", model);
            }else if (variationvalname == "Imagepaths")
            {
                return PartialView("_Productimagepathspartial", model);
            }
            else
                return PartialView("_Productpriceandstockpartial",model);
        }
        [HttpPost]
        public async Task<JsonResult> Editproductvariationfields(Productvariationsmodel model)
        {
            model.Modifiedby = SessionUserData.Staffcode;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Editproductvariationfields(model);
            if (resp.RespStatus>1)
            {
                resp.RespStatus = 2;resp.RespMessage = "Database error occured";         
            }
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }

        #region Other methods
        [HttpGet]
        public async Task<JsonResult> GetListModelbycode(long Valcode, ListModelType Name)
        {
            var data = await bl.GetListModelbycode(Valcode, Name);
            return Json(data);
        }
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
