using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Contracts
{
    public class EquipmentContract
    {
        public virtual string id { get; set; }
        public virtual string alias { get; set; }
        [JsonPropertyName("serial_number")]
        public virtual string serialNumber { get; set; }
        public virtual ModelContract model { get; set; }
        [JsonPropertyName("operating_hours")]
        public OperatingHoursContract operatingHours { get; set; }
        public UnitContract unit { get; set; }
        public virtual LocationContract location { get; set; }
        public virtual OrganizationContract organization { get; set; }
        [JsonPropertyName("initial_operating_hours")]
        public OperatingHoursContract initialOperatingHours { get; set; }
        public virtual string notes { get; set; }
        public TemperatureContract temperature { get; set; }
    }
}