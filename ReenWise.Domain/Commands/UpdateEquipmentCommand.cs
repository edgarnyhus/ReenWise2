using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Commands
{
    public class UpdateEquipmentCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public EquipmentContract EquipmentContract { get; }
        
        public UpdateEquipmentCommand(Guid id, EquipmentContract contract)
        {
            Id = id;
            EquipmentContract = contract;
        }
    }
}
