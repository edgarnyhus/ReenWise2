using ReenWise.Application.Interfaces;
using ReenWise.Domain.Dtos;
using ReenWise.Domain.Commands;
using ReenWise.Domain.Models.Mirror;
using ReenWise.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReenWise.Domain.Contracts;
using ReenWise.Domain.Queries;

namespace ReenWise.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vehicle> _repository;
        private readonly IMediator _mediator;

        public VehicleService(IMapper mapper, IRepository<Vehicle> repository, IMediator mediator)
        {
            _mapper = mapper;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<VehicleDto>> GetVehicles()
        {
            var query = new GetAllVehiclesQuery();
            var result = await _mediator.Send(query);
            return result;
        }
        public async Task<VehicleDto> GetVehicleById(Guid id)
        {
            //var result = _repository.GetById(id);
            //return _mapper.Map<Equipment, EquipmentDto>(result);
            var query = new GetVehicleByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        public async Task<VehicleDto> CreateVehicle(VehicleContract vehicleContract)
        {
            var command = new CreateVehicleCommand(vehicleContract);
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<bool> UpdateVehicle(Guid id, VehicleContract vehicleContract)
        {
            var command = new UpdateVehicleCommand(id, vehicleContract);
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<bool> DeleteVehicle(Guid id)
        {
            var command = new DeleteVehicleCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}