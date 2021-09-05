using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    public class Productvariationsmodel
    {
        public long Productvarcode { get; set; }
        public string Variationname { get; set; }
        public string Variationvalname { get; set; }
        public double Productprice { get; set; }
        public double Productdprice { get; set; }
        public int Productstock { get; set; }
        public string Productdesc { get; set; }
        public string Productfeatures { get; set; }
        public string Productspecification { get; set; }
        public string Productwhatsinbox { get; set; }

        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public IFormFile Productimagefile { get; set; }
        public string Productimagename { get; set; }
        public string Productimagepath { get; set; }
    }
}
