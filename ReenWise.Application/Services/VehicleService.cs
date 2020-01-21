using ReenWise.Application.Interfaces;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Queries;
using ReenWise.Domain.Specifications;

namespace ReenWise.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<VehicleService> _logger;

        public VehicleService(IMapper mapper, IMediator mediator, ILogger<VehicleService> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IEnumerable<VehicleDto>> GetVehicles()
        {
            var query = new GetAllVehicleQuery(new GetVehicleSpecification());
            var result = await _mediator.Send(query);
            var response = _mapper.Map<List<Vehicle>, List<VehicleDto>>(result);
            // Just return one instance of location as defined in VehicleDto - not a List
            foreach (var entity in result)
            {
                var _locationDto = _mapper.Map<Location, LocationDto>(entity.Locations.FirstOrDefault());
                var _entityDto = response.Find(x => x.id == entity.Id);
                _entityDto.location = _locationDto;
            }

            return response;
        }

        public async Task<VehicleDto> GetVehicleById(Guid id)
        {
            var query = new GetVehicleByIdQuery(id);
            var entity = await _mediator.Send(query);
            var response = _mapper.Map<Vehicle, VehicleDto>(entity);
            var _locationDto = _mapper.Map<Location, LocationDto>(entity.Locations.FirstOrDefault());
            response.location = _locationDto;

            return response;
        }

        public async Task<VehicleDto> CreateVehicle(VehicleContract contract)
        {

            //var entity = _mapper.Map<VehicleContract, Vehicle>(vehicleContract);
            //var result = await _mediator.Send(new CreateVehicleCommand(entity));
            //return _mapper.Map<Vehicle, VehicleDto>(result);
            var entity = _mapper.Map<VehicleContract, Vehicle>(contract);
            ConvertPropertyToCollection(entity, contract);

            var command = new CreateVehicleCommand(entity);
            entity = await _mediator.Send(command);

            var _location = entity.Locations.FirstOrDefault();
            var result = _mapper.Map<Vehicle, VehicleDto>(entity);
            result.location = _mapper.Map<Location, LocationDto>(_location);
            _logger.LogInformation($"Created vehicle with id {result.id}");

            return result;

        }

        public async Task<bool> UpdateVehicle(Guid id, VehicleContract contract)
        {
            var entity = _mapper.Map<VehicleContract, Vehicle>(contract);
            ConvertPropertyToCollection(entity, contract);

            var result = await _mediator.Send(new UpdateVehicleCommand(id, entity));
            return result;
        }

        public async Task<bool> DeleteVehicle(Guid id)
        {
            var command = new DeleteVehicleCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }

        private void ConvertPropertyToCollection(Vehicle entity, VehicleContract contract)
        {
            if (contract.location != null)
            {
                var location = _mapper.Map<LocationContract, Location>(contract.location);
                if (entity.Locations == null)
                    entity.Locations = new Collection<Location>();
                entity.Locations.Add(location);
            }
            if (contract.temperature != null)
            {
                var temperature = _mapper.Map<TemperatureContract, Temperature>(contract.temperature);
                if (entity.Temperatures == null)
                    entity.Temperatures = new Collection<Temperature>();
                entity.Temperatures.Add(temperature);
            }
        }

    }
}