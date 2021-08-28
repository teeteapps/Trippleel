using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Model
{
    public class ListModel
    {
        public ListModel()
        {
        }

        public ListModel(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
        public int TypeCode { get; set; }

    }
}
