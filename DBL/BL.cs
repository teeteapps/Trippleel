using Dapper;
using DBL.Enitites;
using DBL.Model;
using DBL.UOW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DBL
{
    public class BL
    {
        private UnitOfWork db;
        private string _connString;
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }

        #region  Product category
        public Task<IEnumerable<Productcategory>> Getproductcategorylist()
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductcategoryRepository.Getproductcategorylist();
                return Resp;
            });
        }

        public Task<GenericModel> Addproductcategory(Productcategory obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductcategoryRepository.Addproductcategory(obj);
                return Resp;
            });
        }
        public Task<IEnumerable<Productsubcategory>> Getcategorydetails(long Categorycode)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductcategoryRepository.Getcategorydetails(Categorycode);
                return Resp;
            });
        }
        public Task<GenericModel> Addproductsubcategory(Productsubcategory obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductcategoryRepository.Addproductsubcategory(obj);
                return Resp;
            });
        }

        #endregion

        #region Product Attributes
        public Task<IEnumerable<Attributes>> GetProductattributeslist()
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductattributesRepository.GetProductattributeslist();
                return Resp;
            });
        }
        public Task<GenericModel> Addproductattributes(Attributes obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductattributesRepository.Addproductattributes(obj);
                return Resp;
            });
        }
        public Task<IEnumerable<Attributevalues>> Getattributedetails(long Attributecode)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductattributesRepository.Getattributedetails(Attributecode);
                return Resp;
            });
        }
        public Task<GenericModel> Addproductattributevalues(Attributevalues obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductattributesRepository.Addproductattributevalues(obj);
                return Resp;
            });
        }
        #endregion
    }
}
