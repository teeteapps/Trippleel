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
        [HttpGet]
        public IActionResult Addproductattribute()
        {
            return PartialView("_Productattributespartial");
        }
        public async Task<JsonResult> Addproductattributes(Attributes model)
        {
            model.Createdby = 100;
            model.Modifiedby = 100;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductattributes(model);
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }

        [HttpGet]
        public async Task<IActionResult> Getattributedetails(long Attributecode, string Attributename)
        {
            Productattributedata data = new Productattributedata();
            data.Attributevaluesdata = await bl.Getattributedetails(Attributecode);
            data.Attributecode = Attributecode;
            data.Attributename = Attributename;
            return PartialView("_Productattributedetails", data);
        }
        [HttpGet]
        public IActionResult Addattributevalues(long Attributecode)
        {
            Attributevalues model = new Attributevalues();
            model.Attributecode = Attributecode;
            return PartialView("_Productattributevaluespartial", model);
        }

        public async Task<JsonResult> Addproductattributevalues(Attributevalues model)
        {
            model.Createdby = 100;
            model.Modifiedby = 100;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductattributevalues(model);
            return Json(new { code = resp.RespStatus, msg = resp.RespMessage });
        }
    }
}
