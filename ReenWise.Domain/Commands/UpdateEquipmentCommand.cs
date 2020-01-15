using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Commands
{
    public class UpdateEquipmentCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public Equipment Equipment { get; }
        
        public UpdateEquipmentCommand(Guid id, Equipment entity)
        {
            Id = id;
            Equipment = entity;
        }
    }
}
