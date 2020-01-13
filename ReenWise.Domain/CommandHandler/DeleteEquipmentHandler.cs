using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.CommandHandler
{
    public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentCommand, bool>
    {
        private readonly IRepository<Equipment> _repository;

        public DeleteEquipmentHandler(IRepository<Equipment> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Delete(request.Id);
            return result;
        }
    }
}
