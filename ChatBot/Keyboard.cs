using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Keyboard
    {
        public string name { get; set; }
        public float? price { get; set; }
        public string style { get; set; }
        public string switches { get; set; }
        public string backlit { get; set; }
        public bool? tenkeyless { get; set; }
        public string connection_type { get; set; }
        public string color { get; set; }

        public Keyboard(string name, float? price, string style, string switches, string backlit, bool? tenkeyless, string connection_type, string color)
        {
            this.name = name;
            this.price = price;
            this.style = style;
            this.switches = switches;
            this.backlit = backlit;
            this.tenkeyless = tenkeyless;
            this.connection_type = connection_type;
            this.color = color;
        }
    }
}
