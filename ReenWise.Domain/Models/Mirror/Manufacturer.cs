#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Manufacturer : EntityBase
    {
        public Manufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
            Equipments = new HashSet<Equipment>();
            Models = new HashSet<Model>();
        }

        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }  
        public virtual ICollection<Vehicle> Vehicles { get; set; }  
    }
}
