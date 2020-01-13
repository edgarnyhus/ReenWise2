using System.Text.Json.Serialization;

namespace ReenWise.Domain.Contracts
{
    public class UnitContract
    {
        public string? id { get; set; }
        [JsonPropertyName("serial_number")]
        public string? serialNumber { get; set; }
        public string? type { get; set; }            // "type": "Abax5"
        public string? health { get; set; }          // "health": "Healthy" - should be a HealthType
        public string status { get; set; }          //"status": "Active" - should be a StatusType
        //Foreign key
    }
}