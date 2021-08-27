using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    [Table("Productsubcategory")]
    public class Productsubcategory
    {
        [NotMapped]
        public static string TableName { get { return "Productsubcategory"; } }
        public long Subctegorycode { get; set; }
        public long Categorycode { get; set; }
        public string Subcategoryname { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
