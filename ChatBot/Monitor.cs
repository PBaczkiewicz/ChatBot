using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Monitor
    {
        public string name { get; set; }
        public float? price { get; set; }
        public float? screen_size { get; set; }
        public int?[] resolution { get; set; }
        public int? refresh_rate { get; set; }
        public float? response_time { get; set; }
        public string panel_type { get; set; }
        public string aspect_ratio {  get; set; }

        //public Monitor(string name, float? price, int? screen_size, int?[] resolution, int? refresh_rate, float? response_time, string panel_type, string aspect_ratio)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.screen_size = screen_size;
        //    this.resolution = resolution;
        //    this.refresh_rate = refresh_rate;
        //    this.response_time = response_time;
        //    this.panel_type = panel_type;
        //    this.aspect_ratio = aspect_ratio;
        //}
    }
}
