using DBL;
using DBL.Enitites;
using DBL.Model;
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
        [HttpGet]
        public async Task<IActionResult> Productcategorylist()
        {
            var data = await bl.Getproductcategorylist();
            return View(data);
        }
        [HttpGet]
        public IActionResult Addproductcategory()
        {
            return PartialView("_Productcategorypartial");
        }
        public async Task<JsonResult> Addproductcategory(Productcategory model)
        {
            model.Createdby = SessionUserData.Staffcode;
            model.Modifiedby = SessionUserData.Staffcode;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductcategory(model);
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }
        [HttpGet]
        public async Task<IActionResult> Getcategorydetails(long Categorycode, string Categoryname)
        {
            Productcategorydata data = new Productcategorydata();
            data.Subcategorydata = await bl.Getcategorydetails(Categorycode);
            data.Categorycode = Categorycode;
            data.Categoryname = Categoryname;
            return PartialView("_Productcategorydetails", data);
        }

        [HttpGet]
        public IActionResult Addproductsubcategory(long Categorycode)
        {
            Productsubcategory model = new Productsubcategory();
            model.Categorycode = Categorycode;
            return PartialView("_Productsubcategorypartial", model);
        }
        public async Task<JsonResult> Addproductsubcategory(Productsubcategory model)
        {
            model.Createdby = SessionUserData.Staffcode;
            model.Modifiedby = SessionUserData.Staffcode;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductsubcategory(model);
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }
    }
}
