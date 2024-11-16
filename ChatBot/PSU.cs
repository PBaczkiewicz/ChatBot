using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class PSU
    {
        public string name { get; set; }
        public float? price { get; set; }
        public string type { get; set; }
        public string efficiency { get; set; }
        public int? wattage { get; set; }
        public string modular { get; set;}
        public string color { get; set; }

        public PSU(string name, float? price, string type, string efficiency, int? wattage, string modular, string color)
        {
            this.name = name;
            this.price = price;
            this.type = type;
            this.efficiency = efficiency;
            this.wattage = wattage;
            this.modular = modular;
            this.color = color;
        }
    }
}
