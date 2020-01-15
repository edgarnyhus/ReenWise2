using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Commands
{
    public class UpdateVehicleCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public Vehicle Vehicle { get; }
        public UpdateVehicleCommand(Guid id, Vehicle entity)
        {
            Id = id;
            Vehicle = entity;
        }
    }

}
