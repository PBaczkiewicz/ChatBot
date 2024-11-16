using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class CPU
    {
        public string name { get; set; }
        public string socket { get; set; }
        public float? price { get; set; }
        public int core_count { get; set; }
        public float core_clock { get; set; }
        public float? boost_clock { get; set; }
        public int tdp { get; set; }
        public string graphics { get; set; }
        public bool smt { get; set; }
        

        //public CPU(string _name, float _price, int _core_count, float _core_clock, float _boost_clock, int _tdp, string _graphics, bool _smt)
        //{
        //    this.name = _name;
        //    this.price = _price;
        //    this.core_count = _core_count;
        //    this.core_clock = _core_clock;
        //    this.boost_clock = _boost_clock;
        //    this.tdp = _tdp;
        //    this.graphics = _graphics;
        //    this.smt = _smt;
        //}

    }
}
