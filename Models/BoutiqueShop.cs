using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class BoutiqueShop
    {
        public int Bid { get; set; }
        public string Bname { get; set; }
        public double Bprice { get; set; }
        public string Bcolor { get; set; }

        public override string ToString()
        {
            string madhu = $"Boutique ID is {Bid} and Boutique name is {Bname} and Price is {Bprice} and color is {Bcolor}";
            return madhu;
        }
    }
}