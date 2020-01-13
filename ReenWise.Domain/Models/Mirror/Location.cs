using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Location : EntityBase
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool InMovement { get; set; }
        public DateTime Timestamp { get; set; }
        public string? SignalSource { get; set; }
        public int? Speed { get; set; }
        public int? Course { get; set; }
        public float? AccuracyRadius { get; set; }
        //public virtual Equipment? Equipment { get; set; }
        //public Guid? EquipmentId { get; set; }
        //public virtual Vehicle? Vehicle { get; set; }
        //public Guid? VehicleId { get; set; }
    }
}