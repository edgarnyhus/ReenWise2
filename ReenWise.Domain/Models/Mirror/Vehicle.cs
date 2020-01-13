#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Vehicle : EntityBase
    {
        public Vehicle()
        {
            Locations = new HashSet<Location>();
            Temperatures = new HashSet<Temperature>();
        }

  
        public string Alias { get; set; }
        public virtual Model Model { get; set; }
        public LicensePlate LicensePlate { get; set; }
        public Guid LicensePlateId { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string? CommercialClass { get; set; }    // "commercial_class": "Commercial",
        public virtual Unit? Unit { get; set ; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual Driver? Driver { get; set; }
        public Guid? DriverId { get; set; }
        public virtual Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }
        public virtual OdoMeter? OdoMeter { get; set; }
        public Guid? OdoMeterId { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<Temperature>? Temperatures { get; set; }
        public string? FuelType { get; set; }        // "fuel_type": "Petrol" - should be a FuelType
        public float? EngineSize { get; set; }
        public string? Color { get; set; }
        public float? Co2Emissions { get; set; }
    }
}
