using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Interfaces;
using ReenWise.Domain.Models.Mirror;

namespace ReenWise.Domain.CommandHandler
{
    public class CreateEquipmentHandler : IRequestHandler<CreateEquipmentCommand, EquipmentDto>
    {
        //private readonly IRepository<Equipment> _repository;
        private readonly IEquipmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateEquipmentHandler(IRepository<Equipment> repository, IMapper mapper)
        {
            _repository = (IEquipmentRepository) repository;
            _mapper = mapper;
        }

        public async Task<EquipmentDto> Handle(CreateEquipmentCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EquipmentContract, Equipment>(command.EquipmentContract);
            if (command.EquipmentContract.location != null)
            {
                var location = _mapper.Map<LocationContract, Location>(command.EquipmentContract.location);
                if (entity.Locations == null)
                    entity.Locations = new Collection<Location>();
                entity.Locations.Add(location);
            }
            if (command.EquipmentContract.temperature != null)
            {
                var temperature = _mapper.Map<TemperatureContract, Temperature>(command.EquipmentContract.temperature);
                if (entity.Temperatures == null)
                    entity.Temperatures = new Collection<Temperature>();
                entity.Temperatures.Add(temperature);
            }

            entity = await _repository.Create(entity);

            //_logger.LogInformation($"Created equipment: {result.Id}");
            var _location = entity.Locations.FirstOrDefault();
            var response = _mapper.Map<Equipment, EquipmentDto>(entity);
            response.location = _mapper.Map<Location, LocationDto>(_location);
            return response;
        }
    }
}
