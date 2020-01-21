#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Model : EntityBase
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
            Equipments = new HashSet<Equipment>();
        }

        public string Name { get; set; }
        public string? SerialNumber { get; set; }
        public string? Description { get; set; }
        public float? Weight { get; set; }
        public float? HHeight { get; set; }
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Volume { get; set; }
        public string? Attachment { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer? Manufacturer { get; set; }
        public Guid? ManufacturerId { get; set; }
        public virtual ICollection<Equipment>? Equipments { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
