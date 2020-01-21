#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
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
        [ForeignKey("ModelId")]
        public Model Model { get; set; }
        public Guid ModelId { get; set; }
        [ForeignKey("LicensePlateId")]
        public LicensePlate LicensePlate { get; set; }
        public Guid LicensePlateId { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string? CommercialClass { get; set; }    // "commercial_class": "Commercial",
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set ; }
        public Guid? UnitId { get; set ; }
        public ICollection<Location> Locations { get; set; }
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        [ForeignKey("DriverId")]
        public Driver? Driver { get; set; }
        public Guid? DriverId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }
        [ForeignKey("OdoMeterId")]
        public OdoMeter? OdoMeter { get; set; }
        public Guid? OdoMeterId { get; set; }
        public string? Notes { get; set; }
        public virtual ICollection<Temperature>? Temperatures { get; set; }
        public string? FuelType { get; set; }        // "fuel_type": "Petrol" - should be a FuelType
        public float? EngineSize { get; set; }
        public string? Color { get; set; }
        public float? Co2Emissions { get; set; }
    }
}
