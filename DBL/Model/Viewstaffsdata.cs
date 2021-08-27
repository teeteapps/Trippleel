using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    [Table("Viewstaffsdata")]
    public class Viewstaffsdata
    {
        [NotMapped]
        public static string TableName { get { return "Viewstaffsdata"; } }
        public string Fullname { get; set; }
    }
}
