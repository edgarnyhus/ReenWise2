using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries.Helpers;

namespace ReenWise.Application.Interfaces
{
    public interface IEquipmentService
    {
        public Task<IEnumerable<EquipmentDto>> GetEquipment(QueryParameters queryParameters);
        public Task<EquipmentDto> GetEquipmentById(Guid id);
        public Task<EquipmentDto> CreateEquipment(EquipmentContract contract);
        public Task<bool> UpdateEquipment(Guid id, EquipmentContract contract);
        public Task<bool> DeleteEquipment(Guid id);
    }
}
