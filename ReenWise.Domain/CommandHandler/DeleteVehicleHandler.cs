using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Queries;

namespace ReenWise.Domain.CommandHandler
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IRepository<Vehicle> _repository;

        public DeleteVehicleHandler(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var result = await  _repository.Remove(request.Id);
            return result;
        }
    }
}
