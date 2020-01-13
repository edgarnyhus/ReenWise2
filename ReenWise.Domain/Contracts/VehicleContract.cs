using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Contracts
{
    public class VehicleContract
    {
        public string id { get; set; }
        public string alias { get; set; }
        public ManufacturerContract manufacturer { get; set; }        // Obtained through VehicleModel?
        public ModelContract model { get; set; }
        [JsonPropertyName("license_plate")]
        public LicensePlateContract licensePlate { get; set; }
        [JsonPropertyName("registered_at")]
        public DateTime registeredAt { get; set; }
        [JsonPropertyName("commerecial_class")]
        public string commercialClass { get; set; }    // "commercial_class": "Commercial",
        public UnitContract unit { get; set; }
        public LocationContract location { get; set; }

        public DriverContract driver { get; set; }
        public OrganizationContract organization { get; set; }
        [JsonPropertyName("odo_meter")]
        public OdoMeterContract odoMeter { get; set; }
        public string notes { get; set; }
        public TemperatureContract temperature { get; set; }
        [JsonPropertyName("fuel_types")]
        public string fuelType { get; set; }        // "fuel_type": "Petrol" - should be a FuelType
        [JsonPropertyName("engine_size")]
        public float engineSize { get; set; }
        public string color { get; set; }
        [JsonPropertyName("co2_emissions")]
        public float co2Emissions { get; set; }
    }
}
