using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    [Table("Attributes")]
    public class Attributes
    {
        [NotMapped]
        public static string TableName { get { return "Attributes"; } }
        public long Attributecode { get; set; }
        public string Attributename { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
