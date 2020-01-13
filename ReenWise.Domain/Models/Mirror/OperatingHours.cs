#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReenWise.Domain.Interfaces;

namespace ReenWise.Domain.Models.Mirror
{
    public class OperatingHours : EntityBase
    {
        public int Hours { get; set; }
        public bool UnitDriven { get; set; }
    }
}
