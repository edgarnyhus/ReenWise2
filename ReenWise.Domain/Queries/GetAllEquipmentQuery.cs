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
        public EquipmentQueryParameters QueryParameters { get; }
        public GetAllEquipmentSpecification Specification { get; set; }

        public GetAllEquipmentQuery(GetAllEquipmentSpecification specification)
        {
            Specification = specification;
        }
    }
}
