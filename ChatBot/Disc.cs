using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatBot
{
    internal class Disc
    {
        public string name { get; set; }
        public float? price { get; set; }
        public float? capacity { get; set; }
        public float? price_per_gb { get; set; }
        public string type { get; set; }
        public int? cache { get; set; }
        public string form_factor { get; set; }
        [JsonProperty("interface")] public string Interface { get; set; }

        //public Disc(string name, float price, int capacity, float price_per_gb, string type, int cache, string form_factor, string Interface)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.capacity = capacity;
        //    this.price_per_gb = price_per_gb;
        //    this.type = type;
        //    this.cache = cache;
        //    this.form_factor = form_factor;
        //    this.Interface = Interface;
        //}
    }
}
