using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class OperatingHoursDto
    {
        public int hours { get; set; }
        [JsonPropertyName("unit_driven")]
        public bool unitDriven { get; set; }
    }
}
