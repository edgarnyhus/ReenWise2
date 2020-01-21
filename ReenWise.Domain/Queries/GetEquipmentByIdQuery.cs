using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.Queries
{
    public class GetEquipmentByIdQuery : IRequest<Equipment>
    {
        public Guid Id { get; }
        public ISpecification<Equipment> Specification { get; set; }

        public GetEquipmentByIdQuery(Guid id, ISpecification<Equipment> specification)
        {
            this.Id = id;
            Specification = specification;
        }
    }
}

