using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;

namespace ReenWise.Domain.Commands
{
    public class CreateVehicleCommand : IRequest<VehicleDto>
    {
        public VehicleContract VehicleContract { get; }
        public CreateVehicleCommand(VehicleContract contract)
        {
            this.VehicleContract = contract;
        }
    }
}
