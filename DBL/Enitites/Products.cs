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
        public bool Hasattributes { get; set; }
        public long Productattributecode { get; set; }
        public List<long> Productattributevaluecode { get; set; }
        public List<long> Productcolorcode { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
