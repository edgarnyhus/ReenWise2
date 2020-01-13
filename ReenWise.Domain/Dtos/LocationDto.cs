using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReenWise.Domain.Dtos
{
    public class LocationDto
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        [JsonPropertyName("in_movement")]
        public bool inMovement { get; set; }
        public DateTime timestamp { get; set; }
        [JsonPropertyName("signal_source")]
        public string signalSource { get; set; }
        public int speed { get; set; }
        public int course { get; set; }
        [JsonPropertyName("accuracy_radius")]
        public float accuracyRadius { get; set; }
    }
}
