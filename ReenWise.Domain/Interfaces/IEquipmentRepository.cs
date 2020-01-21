using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<Equipment> Add(Equipment entity);
        Task<bool> Update(Guid id, Equipment entity);
    }
}
