using System;

namespace ReenWise.Domain.Contracts
{
    public class OdoMeterContract
    {
        public string? id { get; set; }
        public float value { get; set; }
        public DateTime timestamp { get; set; }
    }
}