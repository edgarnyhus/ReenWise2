using System.Text.Json.Serialization;

namespace ReenWise.Domain.Contracts
{
    public class OperatingHoursContract
    {
        public string? id { get; set; }
        public int hours { get; set; }
        [JsonPropertyName("unit_driven")]
        public bool unitDriven { get; set; }
    }
}