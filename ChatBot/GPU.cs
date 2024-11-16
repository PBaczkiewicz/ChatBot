using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class GPU
    {
        public string name { get; set; }
        public float? price { get; set; }
        public string chipset { get; set; }
        public float? memory { get; set; }
        public int? core_clock { get; set; }
        public int? boost_clock { get; set; }
        public string color { get; set; }
        public int? length { get; set; }
    }
}
