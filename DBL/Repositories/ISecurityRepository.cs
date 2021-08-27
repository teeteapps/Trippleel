using DBL.Enitites;
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
    }
}
