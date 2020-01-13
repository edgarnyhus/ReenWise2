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
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, VehicleDto>
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;

        public CreateVehicleHandler(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<VehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<VehicleContract, Vehicle>(request.VehicleContract);
            var result = await _repository.Create(command);
            //_logger.LogInformation($"Created equipment: {equipment.id}");
            return _mapper.Map<Vehicle, VehicleDto>(result);
        }
    }
}
