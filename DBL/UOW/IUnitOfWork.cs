using DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.UOW
{
    public class IUnitOfWork
    {
        ISecurityRepository SecurityRepository { get; }
        IProductcategoryRepository ProductcategoryRepository { get; }
        IProductattributesRepository ProductattributesRepository { get; }
    }
}
