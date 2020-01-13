using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class VehicleDto : EntityBaseDto
    {
        public string alias { get; set; }
        public ModelDto model { get; set; }
        [JsonPropertyName("license_plate")]
        public LicensePlateDto licensePlate { get; set; }
        [JsonPropertyName("registered_at")]
        public DateTime registeredAt { get; set; }
        public LocationDto location { get; set; }
        public DriverDto driver { get; set; }
        public OrganizationDto organization { get; set; }
        public string notes { get; set; }
    }
}
