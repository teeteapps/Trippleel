using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    public class Productcategorydata
    {
        public long Categorycode { get; set; }
        public string Categoryname { get; set; }
        public IEnumerable<Productsubcategory> Subcategorydata { get; set; }
    }
}
