#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Organization : EntityBase
    {
        public Organization()
        {
            Vehicles = new HashSet<Vehicle>();
            Equipment = new HashSet<Equipment>();
            Drivers = new HashSet<Driver>();
        }

        public string Name { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
