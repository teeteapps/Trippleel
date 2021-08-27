using DBL.Enitites;
using DBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface ISecurityRepository
    {
        #region Login User
        GenericModel Login(string userName);
        #endregion
        #region Staffs List 
        IEnumerable<Viewstaffsdata> GetStaffslist();
        #endregion
    }
}
