﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Enitites
{
    public class Productinstockandprices
    {
        public long Productvarcode { get; set; }
        public string Variationname { get; set; }
        public double Productprice { get; set; }
        public double Productdprice { get; set; }
        public int Productstock { get; set; }
    }
}
