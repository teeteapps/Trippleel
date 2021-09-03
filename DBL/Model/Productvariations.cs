using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    [Table("Productvariations")]
    public class Productvariations
    {
        [NotMapped]
        public static string TableName { get { return "Productvariations"; } }
        public long Productvarcode { get; set; }
        public long Productcode { get; set; }
        public long Accountcode { get; set; }
        public long Prodcolorcode { get; set; }
        public long Prodattribvalcode { get; set; }
        public string Productname { get; set; }
        public string Productvariationname { get; set; }
        public string Productbrand { get; set; }
        public long Categorycode { get; set; }
        public long Subcategorycode { get; set; }
        public string Productdesc { get; set; }
        public string Productspec { get; set; }
        public string Productfeatures { get; set; }
        public string Productwhatsinbox { get; set; }
        public double Productprice { get; set; }
        public double Productdprice { get; set; }
        public int Productstock { get; set; }
        public string Productimagepath { get; set; }
        public bool Isproductset { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string Extra { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
        public string Extra6 { get; set; }
        public string Extra7 { get; set; }
        public string Extra8 { get; set; }
        public string Extra9 { get; set; }
        public string Extra10 { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
