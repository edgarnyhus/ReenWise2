using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace ReenWise.Api.Models
{
    public class Location
    {
        public string id { get; set; }
        public Point Point { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int speed { get; set; }
        public bool in_movement { get; set; }
        public int course { get; set; }
        public DateTime timestamp { get; set; }
        public string signal_source { get; set; }
    }
}
