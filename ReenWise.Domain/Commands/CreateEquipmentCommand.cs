using System;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;

namespace ReenWise.Domain.Commands
{
    public class CreateEquipmentCommand : IRequest<EquipmentDto>
    { 
        public EquipmentContract EquipmentContract { get; }
        public CreateEquipmentCommand(EquipmentContract contract)
        {
            EquipmentContract = contract;
        }
    }
}
