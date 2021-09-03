using DBL.Enitites;
using DBL.Enum;
using DBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface IProductRepository
    {
        #region Products
        IEnumerable<Productvariations> Getallproductvariations(long Staffcode);
        GenericModel Addproductsdata(Products entity);
        #endregion


        #region Other methods
        IEnumerable<ListModel> GetListModel(ListModelType listType);
        IEnumerable<ListModel> GetListModelbycode(long Code, ListModelType listType);
        #endregion
    }
}
