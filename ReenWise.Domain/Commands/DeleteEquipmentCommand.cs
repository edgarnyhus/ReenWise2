using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReenWise.Domain.Dtos;

namespace ReenWise.Domain.Commands
{
    public class DeleteEquipmentCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteEquipmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
