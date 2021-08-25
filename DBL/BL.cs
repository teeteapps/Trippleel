using Dapper;
using DBL.Enitites;
using DBL.UOW;
using System;
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
        public Task<GenericModel> Addproductcategory(Productcategory obj)
        {
            return Task.Run(() =>
            {
                var Resp = db.ProductcategoryRepository.Addproductcategory(obj);
                return Resp;
            });
        }
        
        #endregion
    }
}
