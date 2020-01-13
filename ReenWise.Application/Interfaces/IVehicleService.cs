using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;

namespace ReenWise.Application.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleDto>> GetVehicles();
        public Task<VehicleDto> GetVehicleById(Guid id);
        public Task<VehicleDto> CreateVehicle(VehicleContract vehicleContract);
        public Task<bool> UpdateVehicle(Guid id, VehicleContract vehicleContract);
        public Task<bool> DeleteVehicle(Guid id);
    }
}
