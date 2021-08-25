using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    public class Productcategory
    {
        public long Categorycode { get; set; }
        public string Categoryname { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get;set;}
        public DateTime Datemodified { get;set;}
    }
}
