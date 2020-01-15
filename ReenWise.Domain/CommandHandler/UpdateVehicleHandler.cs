using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.CommandHandler
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, bool>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;

        public UpdateVehicleHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.Update(command.Vehicle.Id, command.Vehicle);
            return result;
        }
    }
}
