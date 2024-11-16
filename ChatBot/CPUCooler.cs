using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class CPUCooler
    {
        public string name { get; set; }
        public float? price { get; set; }
        public object rpm { get; set; }
        public object noise_level { get; set; }
        public string color { get; set; }
        public int? size { get; set; }

        //public CPUCooler(string name, float price, object rpm, object noise_level, string color, int size)
        //{
        //    this.name= name;
        //    this.price= price;
        //    this.rpm = rpm;
        //    this.noise_level= noise_level;
        //    this.color= color;
        //    this.size= size;
        //}

        public List<int> GetRpmAsList()
        {
            if (rpm is int singleRpm) return new List<int> { singleRpm };
            return rpm as List<int> ?? new List<int>();
        }

        public List<float> GetNoiseLevelAsList()
        {
            if (noise_level is float singleNoise) return new List<float> { singleNoise };
            return noise_level as List<float> ?? new List<float>();
        }
    }
}
