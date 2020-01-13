using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class DriverDto : EntityBaseDto
    {
        public OrganizationDto organization { get; set; }
        [JsonPropertyName("vehicleid")]
        public string vehicleId { get; set; }
        public string name { get; set; }
        [JsonPropertyName("phone_number")]
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
}
