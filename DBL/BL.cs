using Dapper;
using DBL.Enitites;
using DBL.Enum;
using DBL.Helpers;
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

        #region User Login
        public Task<UserModel> Login(string userName, string password)
        {
            return Task.Run(() =>
            {
                UserModel userModel = new UserModel { };
                var resp = db.SecurityRepository.Login(userName);
                if (resp.RespStatus == 0)
                {
                    EncryptDecrypt sec = new EncryptDecrypt();
                    string enccpass = sec.Encrypt(password);
                    string descpass = sec.Decrypt(resp.Data4);

                    if (password == descpass)
                    {
                        userModel = new UserModel
                        {
                            Staffcode = Convert.ToInt64(resp.Data1),
                            Fullname = resp.Data2,
                            PhoneNo = resp.Data3,
                            Email = resp.Data6,
                            profilecode = Convert.ToInt32(resp.Data7)

                        };
                        return userModel;
                    }
                    else
                    {
                        userModel.RespStatus = 1;
                        userModel.RespMessage = "Incorrect Password!";
                    }
                }
                else
                {
                    userModel.RespStatus = 1;
                    userModel.RespMessage = "Incorrect Password!";
                }

                return userModel;
            });
        }
        #endregion

        #region Staffs List
        public Task<IEnumerable<Viewstaffsdata>> GetStaffslist()
        {
            return Task.Run(() =>
            {
                var Resp = db.SecurityRepository.GetStaffslist();
                return Resp;
            });
        }
        #endregion

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

        #region Products
        
         public Task<IEnumerable<Productvariations>> Getallproductvariations(long Staffcode)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductRepository.Getallproductvariations(Staffcode);
                return Resp;
            });
        }
        public Task<GenericModel> Addproductsdata(Products obj)
        {
            return Task.Run(() =>
            {
                
                if (obj.Productcolorcode != null)
                {
                    obj.Productcolorcodedata = string.Join(",",obj.Productcolorcode);
                }
                if (obj.Productattributevaluecode!=null)
                {
                    obj.Productattributevaluecodedata = string.Join(",",obj.Productattributevaluecode);
                }
                var Resp = db.ProductRepository.Addproductsdata(obj);
                return Resp;
            });
        }
        #endregion


        #region Other methods
        public Task<IEnumerable<ListModel>> GetListModel(ListModelType listType)
        {
            return Task.Run(() =>
            {
                return db.ProductRepository.GetListModel(listType);
            });
        }
        public Task<IEnumerable<ListModel>> GetListModelbycode(long Code,ListModelType listType)
        {
            return Task.Run(() =>
            {
                return db.ProductRepository.GetListModelbycode(Code,listType);
            });
        }
        #endregion
    }
}
