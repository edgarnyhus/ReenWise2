using System.Text.Json.Serialization;

namespace ReenWise.Domain.Contracts
{
    public class ModelContract
    {
        public string? id { get; set; }
        public string name { get; set; }
        [JsonPropertyName("serial_number")]
        public string? serialNumber { get; set; }
        public string? description { get; set; }
        public float? weight { get; set; }
        public float? height { get; set; }
        public float? length { get; set; }
        public float? width { get; set; }
        public float? volume { get; set; }
        public string? attachment { get; set; }
    }
}