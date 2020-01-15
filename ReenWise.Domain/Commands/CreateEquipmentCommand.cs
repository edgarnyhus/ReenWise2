using System;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Commands
{
    public class CreateEquipmentCommand : IRequest<Equipment>
    { 
        public Equipment Equipment { get; }
        public CreateEquipmentCommand(Equipment entity)
        {
            Equipment = entity;
        }
    }
}
