#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Unit : EntityBase
    {
        public string? SerialNumber { get; set; }
        public string? Type { get; set; }            // "type": "Abax5"
        public string? Health { get; set; }          // "health": "Healthy" - should be a HealthType
        public string? Status { get; set; }           //"status": "Active" - should be a StatusType
        //public virtual Equipment Equipment { get; set; }
        //public virtual Vehicle Vehicle { get; set; }
    }
}
