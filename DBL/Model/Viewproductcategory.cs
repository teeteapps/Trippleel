using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    [Table("Viewproductcategory")]
    public class Viewproductcategory
    {
        [NotMapped]
        public static string TableName { get { return "Viewproductcategory"; } }
        public long Categorycode { get; set; }
        public long Subcategorycode { get; set; }
        public string Categoryname { get; set; }
        public string Subcategoryname { get; set; }
    }
}
