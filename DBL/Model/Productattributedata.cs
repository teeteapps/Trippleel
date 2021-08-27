using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    public class Productattributedata
    {
        public long Attributecode { get;set;}
        public string Attributename { get;set;}
        public IEnumerable<Attributevalues> Attributevaluesdata { get; set; }
    }
}
