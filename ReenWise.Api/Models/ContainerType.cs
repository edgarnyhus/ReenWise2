using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReenWise.Api.Models
{
    public class ContainerType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sap_number { get; set; }
        public string description { get; set; }
        public int weight_kg { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int volume_kg { get; set; }
        public string attachment { get; set; }
    }
}
