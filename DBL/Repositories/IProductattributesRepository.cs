using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface IProductattributesRepository
    {
        #region Product Attributes
        IEnumerable<Attributes> GetProductattributeslist();
        GenericModel Addproductattributes(Attributes entity);
        IEnumerable<Attributevalues> Getattributedetails(long Attributecode);
        #endregion
    }
}
