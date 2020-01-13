using System;

namespace ReenWise.Domain.Contracts
{
    public class TemperatureContract
    {
        public string? id { get; set; }
        public float value { get; set; }
        public DateTime timestamp { get; set; }
    }
}