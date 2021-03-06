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
        public  string Productbrand { get; set; }
        public long Accountcode { get; set; }
        public long Categorycode { get; set; }
        public long Subcategorycode { get; set; }
        //public int Hasattributedata { get; set; }
        public int Hasattributes { get; set; }
        public long Productattributecode { get; set; }
        public List<long> Productattributevaluecode { get; set; }
        public string Productattributevaluecodedata { get; set; }
        public List<long> Productcolorcode { get; set; }
        public string Productcolorcodedata { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
