using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Motherboard
    {
        public string name {  get; set; }
        public float? price { get; set; }
        public string socket { get; set; }
        public string form_factor { get; set; }
        public int? max_memory { get; set; }
        public int? memory_slots {  get; set; }
        public string color { get; set; }

        //public Motherboard(string name, float? price, string socket, string form_factor, int? max_memory, int? memory_slots, string color)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.socket = socket;
        //    this.form_factor = form_factor;
        //    this.max_memory = max_memory;
        //    this.memory_slots = memory_slots;
        //    this.color = color;
        //}
    }
}
