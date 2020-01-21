#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class Temperature : EntityBase
    {
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
