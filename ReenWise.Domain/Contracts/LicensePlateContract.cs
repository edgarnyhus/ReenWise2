using System;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Contracts
{
    public class LicensePlateContract
    {
        public string? id { get; set; }
        public string number { get; set; }
        [JsonPropertyName("registration_date")]
        public DateTime registrationDate { get; set; }
    }
}