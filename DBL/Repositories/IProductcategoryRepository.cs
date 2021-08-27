using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface IProductcategoryRepository
    {
        #region product Category
        IEnumerable<Productcategory> Getproductcategorylist();
        GenericModel Addproductcategory(Productcategory entity);
        Productcategory Getcategorydetails(long Categorycode);
        GenericModel Addproductsubcategory(Productsubcategory entity);
        #endregion
    }
}
