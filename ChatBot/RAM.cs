using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class RAM
    {
        public string name { get; set; }
        public float? price { get ; set; }
        public object speed { get ; set; }
        public object modules { get; set; }
        public float? price_per_gb { get; set; }
        public string color { get; set; }
        public float? first_word_latency { get; set; }
        public float? cas_latency { get; set; }


        public List<int> GetSpeedAsList()
        {
            if (speed is int singleRpm) return new List<int> { singleRpm };
            return speed as List<int> ?? new List<int>();
        }

        public List<int> GetModulesAsList()
        {
            if (modules is int singleRpm) return new List<int> { singleRpm };
            return modules as List<int> ?? new List<int>();
        }



        //public RAM(string name, float? price, int?[] speed, int?[] modules, float? price_per_gb, string color, int? first_word_latency, int? cas_latency)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.speed = speed;
        //    this.modules = modules;
        //    this.price_per_gb = price_per_gb;
        //    this.color = color;
        //    this.first_word_latency = first_word_latency;
        //    this.cas_latency = cas_latency;
        //}
    }
}
