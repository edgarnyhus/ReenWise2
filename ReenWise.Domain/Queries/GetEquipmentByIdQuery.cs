using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Queries
{
    public class GetEquipmentByIdQuery : IRequest<Equipment>
    {
        public Guid Id { get; }

        public GetEquipmentByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}

