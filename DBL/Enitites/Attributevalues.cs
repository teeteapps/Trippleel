using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    [Table("Attributevalues")]
    public class Attributevalues
    {
        [NotMapped]
        public static string TableName { get { return "Attributevalues"; } }
        public long Attributevalcode { get; set; }
        public long Attributecode { get; set; }
        public string Attributevalname { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
