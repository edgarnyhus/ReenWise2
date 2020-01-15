using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Commands
{
    public class CreateVehicleCommand : IRequest<Vehicle>
    {
        public Vehicle Vehicle { get; }
        public CreateVehicleCommand(Vehicle entity)
        {
            this.Vehicle = entity;
        }
    }
}
