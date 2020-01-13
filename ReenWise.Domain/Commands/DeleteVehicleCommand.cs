using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Commands
{
    public class DeleteVehicleCommand :  IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteVehicleCommand(Guid id)
        {
            Id = id;
        }
    }
}
