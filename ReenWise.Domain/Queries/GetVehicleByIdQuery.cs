using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Queries
{
    public class GetVehicleByIdQuery : IRequest<Vehicle>
    {
        public Guid Id { get; }

        public GetVehicleByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
