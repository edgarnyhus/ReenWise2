using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class LicensePlateDto
    {
        public string number { get; set; }
        [JsonPropertyName("registration_date")]
        public DateTime registrationDate { get; set; }
    }
}
