using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;

namespace ReenWise.Domain.Queries
{
    public class GetEquipmentByIdQuery : IRequest<EquipmentDto>
    {
        public Guid Id { get; }

        public GetEquipmentByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}

