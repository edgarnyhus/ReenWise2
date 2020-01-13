using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Commands
{
    public class UpdateVehicleCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public VehicleContract VehicleContract { get; }
        public UpdateVehicleCommand(Guid id, VehicleContract contract)
        {
            Id = id;
            VehicleContract = contract;
        }
    }

}
