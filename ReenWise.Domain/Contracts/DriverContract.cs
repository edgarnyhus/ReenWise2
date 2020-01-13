using System;

namespace ReenWise.Domain.Contracts
{
    public class DriverContract
    {
        public string id { get; set; }
        public OrganizationContract organization { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string? email { get; set; }
        // Foreign key
        //public string? vehicleId { get; set; }
    }
}