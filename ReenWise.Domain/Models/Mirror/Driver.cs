using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Text;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Driver : EntityBase
    {
        public Driver()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization? Organization { get; set; }
        public Guid? OrganizationId { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}