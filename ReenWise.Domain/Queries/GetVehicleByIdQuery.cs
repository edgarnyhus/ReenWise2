using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Queries
{
    public class GetVehicleByIdQuery : IRequest<VehicleDto>
    {
        public Guid Id { get; }

        public GetVehicleByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
