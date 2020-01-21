using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Queries.Helpers;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Specifications;

namespace ReenWise.Domain.Queries
{
    public class GetAllEquipmentQuery :IRequest<List<Equipment>>
    {
        public GetEquipmentSpecification Specification { get; set; }

        public GetAllEquipmentQuery(GetEquipmentSpecification specification)
        {
            Specification = specification;
        }
    }
}
