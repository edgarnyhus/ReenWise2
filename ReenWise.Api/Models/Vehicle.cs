using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReenWise.Api.Models
{
    public class Vehicle
    {
        public Item[] items { get; set; }
        public string id { get; set; }
        public class Item
        {
            public string id { get; set; }
            public string alias { get; set; }
            public Manufacturer manufacturer { get; set; }
            public Model model { get; set; }
            public License_Plate license_plate { get; set; }
            public string commercial_class { get; set; }
            public DateTime registered_at { get; set; }
            public Unit unit { get; set; }
            public Location location { get; set; }
            public Driver driver { get; set; }
            public Organization organization { get; set; }
            public Odometer odometer { get; set; }
            public string notes { get; set; }
            public Temperature temperature { get; set; }
            public string fuel_type { get; set; }
            public int engine_size { get; set; }
            public string color { get; set; }
            public int co2_emissions { get; set; }
        }

        public class Manufacturer
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Model
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class License_Plate
        {
            public string id { get; set; }
            public string number { get; set; }
            public DateTime registration_date { get; set; }
        }

        public class Unit
        {
            public string id { get; set; }
            public string serial_number { get; set; }
            public string type { get; set; }
            public string health { get; set; }
            public string status { get; set; }
        }

        public class Driver
        {
            public string id { get; set; }
            public string name { get; set; }
            public string phone_number { get; set; }
            public string email { get; set; }
        }

        public class Odometer
        {
            public string id { get; set; }
            public float value { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class Temperature
        {
            public string id { get; set; }
            public int value { get; set; }
            public DateTime timestamp { get; set; }
        }
    }
}
