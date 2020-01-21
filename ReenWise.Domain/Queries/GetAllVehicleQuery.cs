using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Queries
{
    public class GetAllVehicleQuery : IRequest<List<Vehicle>>
    {
        public ISpecification<Vehicle> Specification { get; set; }

        public GetAllVehicleQuery(ISpecification<Vehicle> specification)
        {
            Specification = specification;
        }
    }
}
