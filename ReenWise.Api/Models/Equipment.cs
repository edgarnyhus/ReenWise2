using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReenWise.Api.Models
{
    public class Equipment
    {

        public string id { get; set; }
        public Item[] containers { get; set; }

        public class Item
        {
            public string id { get; set; }
            public string alias { get; set; }
            public ContainerType model { get; set; }
            public Location location { get; set; }
            public Organization organization { get; set; }
            public string notes { get; set; }
        }
    }
}
