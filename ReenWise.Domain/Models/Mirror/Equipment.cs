#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Equipment : EntityBase
    {
        public Equipment()
        {
            //Locations = new HashSet<Location>();
            //Temperatures = new HashSet<Temperature>();
        }
        public string Alias { get; set; }
        public string? SerialNumber { get; set; }
        public virtual Model Model { get; set; }
        [ForeignKey("ModelId")]
        public Guid? ModelId { get; set; }
        [ForeignKey("OperatingHoursId")]
        public virtual OperatingHours? OperatingHours { get; set; }
        public Guid? OperatingHoursId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit? Unit { get; set; }
        public Guid? UnitId { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        [Column(TypeName = "geometry")]
        public NetTopologySuite.Geometries.Point Location { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public Guid? OrganizationId { get; set; }
        [ForeignKey("InitialOperatingHoursId")]
        public virtual OperatingHours? InitialOperatingHours { get; set; }
        public Guid? InitialOperatingHoursId { get; set; }
        public virtual ICollection<Temperature>? Temperatures { get; set; }
        public string? Notes { get; set; }
    }
}