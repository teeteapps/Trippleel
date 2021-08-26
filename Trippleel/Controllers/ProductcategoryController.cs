﻿using DBL;
using DBL.Enitites;
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
        [HttpGet]
        public IActionResult Addproductcategory()
        {
            return PartialView("_Productcategorypartial");
        }
        public async Task<JsonResult> Addproductcategory(Productcategory model)
        {
            model.Createdby = 100;
            model.Modifiedby = 100;
            model.Datecreated = DateTime.Now;
            model.Datemodified = DateTime.Now;
            var resp = await bl.Addproductcategory(model);
            return Json(new {code=resp.RespStatus, msg = resp.RespMessage });
        }
    }
}
