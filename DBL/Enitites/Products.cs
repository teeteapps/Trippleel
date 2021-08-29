using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    public class Products
    {
        public  string Productname { get; set; }
        public long Categorycode { get; set; }

        public long Subcategorycode { get; set; }
        public long Productattribute { get; set; }
        public long Productattributevaluecode { get; set; }


        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
