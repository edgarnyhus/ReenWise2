﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReenWise.Application.Interfaces;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Queries;
using ReenWise.Domain.Queries.Helpers;
using ReenWise.Domain.Specifications;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace ReenWise.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<EquipmentService> _logger;

        public EquipmentService(IMapper mapper, IMediator mediator, ILogger<EquipmentService> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IEnumerable<EquipmentDto>> GetEquipment(QueryParameters queryParameters)
        {
            
            var query = new GetAllEquipmentQuery(new GetEquipmentSpecification(queryParameters));
            _logger.LogInformation($"GetEquipment: Making query {query.ToString()}");

            var result = await _mediator.Send(query);
            var response = _mapper.Map<List<Equipment>, List<EquipmentDto>>(result);
            // Just return one instance of location as defined in EquipmentDto - not a list
            foreach (var entity in result)
            {
                if (entity.Locations != null)
                {
                    var _locationDto = _mapper.Map<Location, LocationDto>(entity.Locations.FirstOrDefault());
                    var _entityDto = response.Find(x => x.id == entity.Id);
                    _entityDto.location = _locationDto;
                }
            }

            return response;
        }

        public async Task<EquipmentDto> GetEquipmentById(Guid id)
        {
            var query = new GetEquipmentByIdQuery(id, new GetEquipmentSpecification(id));
            var entity = await _mediator.Send(query);
            var response = _mapper.Map<Equipment, EquipmentDto>(entity);
            if (entity.Locations != null)
            {
                var _locationDto = _mapper.Map<Location, LocationDto>(entity.Locations.FirstOrDefault());
                response.location = _locationDto;
            }

            return response;
        }

        public async Task<EquipmentDto> CreateEquipment(EquipmentContract contract)
        {
            var entity = _mapper.Map<EquipmentContract, Equipment>(contract);
            ConvertPropertyToCollection(entity, contract);

            var command = new CreateEquipmentCommand(entity);
            entity = await _mediator.Send(command);

            var _location = entity.Locations.FirstOrDefault();
            var result = _mapper.Map<Equipment, EquipmentDto>(entity);
            result.location = _mapper.Map<Location, LocationDto>(_location);
            _logger.LogInformation($"Created equipment with id {result.id}");

            return result;
        }

        public async Task<bool> UpdateEquipment(Guid id, EquipmentContract contract)
        {
            var entity = _mapper.Map<EquipmentContract, Equipment>(contract);
            ConvertPropertyToCollection(entity, contract);

            var command = new UpdateEquipmentCommand(id, entity);
            var result = await _mediator.Send(command);

            return result;
        }

        public async Task<bool> DeleteEquipment(Guid id)
        {
            var command = new DeleteEquipmentCommand(id);
            _logger.LogInformation($"DeleteEquipment: {command.ToString()}");
            var result = await _mediator.Send(command);
            return result;
        }

        private void ConvertPropertyToCollection(Equipment entity, EquipmentContract contract)
        {
            if (contract.location != null)
            {
                var location = _mapper.Map<LocationContract, Location>(contract.location);
                if (entity.Locations == null)
                    entity.Locations = new Collection<Location>();
                //location.Point = CreatePoint(location.Latitude, location.Longitude);
                entity.Locations.Add(location);

                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                entity.Location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate(location.Latitude, location.Longitude));
            }
            if (contract.temperature != null)
            {
                var temperature = _mapper.Map<TemperatureContract, Temperature>(contract.temperature);
                if (entity.Temperatures == null)
                    entity.Temperatures = new Collection<Temperature>();
                entity.Temperatures.Add(temperature);
            }
        }

        //public static DbGeography CreatePoint(double latitude, double longitude)
        //{
        //    var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
        //        "POINT({0} {1})", longitude, latitude);
        //    // 4326 is most common coordinate system used by GPS/Maps
        //    return DbGeography.PointFromText(text, 4326);
        //}
    }
}
