using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Queries.Helpers;
using ReenWise.Domain.Models;

namespace ReenWise.Domain.Queries
{
    public class GetAllEquipmentQuery :IRequest<List<EquipmentDto>>
    {
        public EquipmentQueryParameters QueryParameters { get; }

        public GetAllEquipmentQuery(EquipmentQueryParameters queryParameters)
        {
            QueryParameters = queryParameters;
        }
    }
}
